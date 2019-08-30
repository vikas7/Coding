using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace WebConfigEditor.ViewModel
{
    class WebConfigViewModel : INotifyPropertyChanged
    {
        private string _txtConfigFilePath = "There is not string ";
        private ICommand _browseFile;
        private ICommand _changeFileConfiguration;
        private SSLCategory _ssl;
        private AuthenticationOptions _authOptions;
        private bool _ssoEnabled;
        private bool _filePathExist = false;
        private const string CONFIG_FILE_FILTER = "Configuration Files|*.config";
        public string TxtConfigFilePath
        {
            get { return _txtConfigFilePath; }
            set
            {
                if (value == null)
                    return;
                _txtConfigFilePath = value;
                if (!Path.GetFileName(TxtConfigFilePath).Equals("Web.config")
                    && !Path.GetFileName(TxtConfigFilePath).Equals("web.config")
                    && !Path.GetFileName(TxtConfigFilePath).Equals("web.Config")
                    && !Path.GetFileName(TxtConfigFilePath).Equals("Web.Config"))
                {
                    FilepathExist = false;
                }
                else
                {
                    FilepathExist = true;
                }
                OnPropertyChange("TxtConfigFilePath");

            }
        }

        public SSLCategory SSL
        {
            get { return _ssl; }
            set
            {
                if (value == _ssl)
                    return;
                _ssl = value;
                OnPropertyChange("SSL");
            }
        }
        public bool SSOEnabled
        {
            get
            {
                return _ssoEnabled;
            }
            set
            {
                if (_ssoEnabled == value)
                {
                    return;
                }
                _ssoEnabled = value;
                OnPropertyChange("SSOEnabled");
            }
        }


        public AuthenticationOptions AuthOptions
        {
            get
            {
                return _authOptions;
            }
            set
            {
                if (_authOptions == value)
                    return;
                _authOptions = value;
                OnPropertyChange("AuthOptions");
            }
        }
        public bool FilepathExist
        {
            get
            {
                return _filePathExist;
            }
            set
            {
                if (_filePathExist == value)
                {
                    return;
                }
                _filePathExist = value;
                OnPropertyChange("FilepathExist");
            }
            
        }

        public ICommand BrowseFile
        {
            get
            {
                if (_browseFile == null)
                {
                    _browseFile = new RelayCommand(BrowseFileMethod);

                }
                return _browseFile;
            }

        }
        public ICommand ChangeFileConfiguration
        {
            get
            {
                if (_changeFileConfiguration == null)
                {
                    _changeFileConfiguration = new RelayCommand(DoModificationInConfigFile);
                }
                return _changeFileConfiguration;
            }
        }

        private void DoModificationInConfigFile(object obj)
        {
            string file = TxtConfigFilePath;
            if (!File.Exists(file))
            {
                return;
            }

            BackupConfigFile(file);
            XmlDocument doc = new XmlDocument();
            StreamReader stream = new StreamReader(file);
            using (stream)
            {
                doc.Load(stream);
            }

            DoConfigurationChanges(doc);
            FileInfo fileInfo = new FileInfo(file);



            // XmlTextWriter textWriter = new XmlTextWriter(Path.GetDirectoryName(file)+"\\"+Path.GetFileName(file), null);
            doc.Save(file);
        }

        private void DoConfigurationChanges(XmlDocument doc)
        {
            DoSSOChanges(doc);
            DoAuthenticationChange(doc);
            DoBehaviourChange(doc);
            DoBindingChanges(doc);
        }

        private void DoBindingChanges(XmlDocument doc)
        {
            XmlNodeList bindingList = doc.GetElementsByTagName("binding");
            foreach (XmlNode node in bindingList)
            {
                if (node.ParentNode.Name == "webHttpBinding")
                {
                    ConfigureWebHttpBinding(doc, node);
                }
                if (node.ParentNode.Name == "customBinding")
                {
                    ConfigureCustomBinding(doc, node);
                }
            }
        }

        private void ConfigureCustomBinding(XmlDocument doc, XmlNode node)
        {
            XmlAttributeCollection xmlAttributeCollection = node.Attributes;
            foreach (XmlAttribute xmlAttribute in xmlAttributeCollection)
            {
                if (xmlAttribute.Name == "name" && (xmlAttribute.Value == "binaryHttpBinding" || xmlAttribute.Value == "binaryHttpBindingStreaming"))
                {
                    XmlNodeList xmlNodeList = node.ChildNodes;
                    foreach (XmlNode childNode in xmlNodeList)
                    {
                        if (childNode.Name == "httpTransport" || childNode.Name == "httpsTransport")
                        {
                            node.RemoveChild(childNode);
                            break;
                        }
                    }

                    XmlElement transportNode = doc.CreateElement(SSL == SSLCategory.SSL ? "httpsTransport" : "httpTransport");

                    XmlAttribute maxReceivedMessageSizeAttribute = doc.CreateAttribute("maxReceivedMessageSize");
                    maxReceivedMessageSizeAttribute.Value = "1024000000";
                    transportNode.Attributes.Append(maxReceivedMessageSizeAttribute);

                    XmlAttribute maxBufferSizeAttribute = doc.CreateAttribute("maxBufferSize");
                    maxBufferSizeAttribute.Value = "1024000000";
                    transportNode.Attributes.Append(maxBufferSizeAttribute);
                    if (xmlAttribute.Value == "binaryHttpBindingStreaming")
                    {
                        XmlAttribute transferModeAttribute = doc.CreateAttribute("transferMode");
                        transferModeAttribute.Value = "StreamedRequest";
                        transportNode.Attributes.Append(transferModeAttribute);
                    }
                    if (AuthOptions == AuthenticationOptions.Basic_Authentication || AuthOptions == AuthenticationOptions.Windows_Authentication)
                    {
                        XmlAttribute authenticationSchemeAttribute = doc.CreateAttribute("authenticationScheme");
                        authenticationSchemeAttribute.Value = AuthOptions == AuthenticationOptions.Basic_Authentication ? "Basic" : "Negotiate";
                        transportNode.Attributes.Append(authenticationSchemeAttribute);
                    }
                    node.AppendChild(transportNode);
                }
            }

        }

        private void ConfigureWebHttpBinding(XmlDocument doc, XmlNode node)
        {
            XmlNodeList xmlNodeList = node.ChildNodes;
            foreach (XmlNode childNode in xmlNodeList)
            {
                if (childNode.Name == "security")
                {
                    node.RemoveChild(childNode);
                    break;
                }
            }

            if (SSL == SSLCategory.SSL && AuthOptions != AuthenticationOptions.Basic_Authentication && AuthOptions != AuthenticationOptions.Windows_Authentication)
            {
                return;
            }


            XmlElement securityElement = doc.CreateElement("security");

            XmlAttribute modeAttribute = doc.CreateAttribute("mode");
            modeAttribute.Value = SSL == SSLCategory.SSL ? "Transport" : "TransportCredentialOnly";
            securityElement.Attributes.Append(modeAttribute);
            node.AppendChild(securityElement);


            if (AuthOptions == AuthenticationOptions.Basic_Authentication)
            {
                XmlElement transportNode = doc.CreateElement("transport");
                XmlAttribute clientCredentialTypeAttribute = doc.CreateAttribute("clientCredentialType");
                clientCredentialTypeAttribute.Value = "Basic";
                transportNode.Attributes.Append(clientCredentialTypeAttribute);
                securityElement.AppendChild(transportNode);
            }

            if (AuthOptions == AuthenticationOptions.Windows_Authentication)
            {
                XmlElement transportNode = doc.CreateElement("transport");
                XmlAttribute clientCredentialTypeAttribute = doc.CreateAttribute("clientCredentialType");
                clientCredentialTypeAttribute.Value = "Windows";
                transportNode.Attributes.Append(clientCredentialTypeAttribute);
                securityElement.AppendChild(transportNode);
            }
        }

        private void DoBehaviourChange(XmlDocument doc)
        {
            XmlNodeList serviceMetadataList = doc.GetElementsByTagName("serviceMetadata");
            foreach (XmlNode node in serviceMetadataList)
            {
                if (node.ParentNode.Name == "behavior")
                {
                    // get the existing value, or default to false
                    string existingValue = string.Empty;

                    try
                    {
                        foreach (XmlAttribute attribute in node.Attributes)
                        {
                            if (attribute.Name.ToLower().Contains("getenabled"))
                            {
                                existingValue = attribute.Value;
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        existingValue = "false";
                    }
                    XmlAttribute getEnabledAttribute = doc.CreateAttribute(SSOEnabled ? "httpsGetEnabled" : "httpGetEnabled");
                    getEnabledAttribute.Value = existingValue;
                    node.Attributes.Append(getEnabledAttribute);
                    node.Attributes.RemoveNamedItem(SSL == SSLCategory.SSL ? "httpGetEnabled" : "httpsGetEnabled");
                }
            }
        }

        private void DoAuthenticationChange(XmlDocument doc)
        {
            XmlNodeList authentication = doc.GetElementsByTagName("authentication");
            foreach (XmlNode node in authentication)
            {
                if (node.ParentNode.Name == "system.web" && node.ParentNode.ParentNode.Name == "configuration")
                {
                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        if (attribute.Name == "mode")
                        {
                            attribute.Value = AuthOptions == AuthenticationOptions.Basic_Authentication || AuthOptions == AuthenticationOptions.Windows_Authentication ? "Windows" : "None";
                            break;
                        }
                    }
                }
            }
            XmlNodeList authorization = doc.GetElementsByTagName("authorization");
            XmlNodeList systemWebList = doc.GetElementsByTagName("system.web");
            XmlNode systemWebNode = null;
            foreach (XmlNode node in systemWebList)
            {
                if (node.ParentNode.Name == "configuration")
                {
                    systemWebNode = node;
                    break;
                }
            }
            foreach (XmlNode node in authorization)
            {
                if (systemWebNode != null && node.ParentNode.Name == "system.web" && node.ParentNode.ParentNode.Name == "configuration")
                {
                    systemWebNode.RemoveChild(node);
                    break;
                }
            }
            if (AuthOptions == AuthenticationOptions.Windows_Authentication)
            {
                if (systemWebNode != null)
                {
                    XmlElement newAuthorizationElement = doc.CreateElement("authorization");
                    XmlElement newAllowElement = doc.CreateElement("allow");
                    XmlAttribute usersAttribute = doc.CreateAttribute("users");
                    usersAttribute.Value = "*";
                    newAllowElement.Attributes.Append(usersAttribute);
                    newAuthorizationElement.AppendChild(newAllowElement);
                    systemWebNode.AppendChild(newAuthorizationElement);
                }
            }
        }

        private void DoSSOChanges(XmlDocument doc)
        {
            XmlNodeList location = doc.GetElementsByTagName("location");
            XmlNodeList root = doc.GetElementsByTagName("configuration");
            if (location.Count > 0)
            {
                root[0].RemoveChild(location[0]);
            }

            if (SSOEnabled && AuthOptions == AuthenticationOptions.Windows_Authentication)
            {
                XmlElement newLocationElement = doc.CreateElement("location");
                XmlAttribute pathAttribute = doc.CreateAttribute("path");
                pathAttribute.Value = "default.aspx";
                newLocationElement.Attributes.Append(pathAttribute);

                XmlElement newSystemWebElement = doc.CreateElement("system.web");
                XmlElement newAuthorizationElement = doc.CreateElement("authorization");
                XmlElement newDenyElement = doc.CreateElement("deny");
                XmlAttribute usersAttribute = doc.CreateAttribute("users");
                usersAttribute.Value = "?";
                newDenyElement.Attributes.Append(usersAttribute);
                newAuthorizationElement.AppendChild(newDenyElement);
                newSystemWebElement.AppendChild(newAuthorizationElement);
                newLocationElement.AppendChild(newSystemWebElement);

                root[0].AppendChild(newLocationElement);
            }
        }

        private void BackupConfigFile(string file)
        {
            if (File.Exists(file))
            {
                string backupFile = string.Format("{0}\\{1}_{2:MM}{2:dd}{2:yyyy}{2:mm}", Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file), DateTime.Now, Path.GetExtension(file), DateTime.Now.Second, DateTime.Now.Minute);
                File.Copy(file, backupFile, true);
            }
        }

        private void BrowseFileMethod(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = CONFIG_FILE_FILTER;
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                TxtConfigFilePath = openFileDialog.FileName;
            }
            UpdateTheSSLWindow(TxtConfigFilePath);
        }

        private void UpdateTheSSLWindow(string txtConfigFilePath)
        {
            if (!File.Exists(txtConfigFilePath))
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(txtConfigFilePath);
            XmlNodeList xmlNodelist = doc.GetElementsByTagName("serviceMetadata");
            foreach (XmlNode node in xmlNodelist)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    if (attribute.Name == "httpsGetEnabled")
                    {
                        SSL = SSLCategory.SSL;
                    }
                    else if (attribute.Name == "httpGetEnabled")
                    {
                        SSL = SSLCategory.NonSSL;
                    }
                }
            }
            XmlNodeList bindings = doc.GetElementsByTagName("binding");
            foreach (XmlNode node in bindings)
            {
                if (node.ParentNode.Name == "webHttpBinding")
                {
                    foreach (XmlNode securityChild in node.ChildNodes)
                    {
                        if (securityChild.Name == "security")
                        {
                            foreach (XmlNode transportChild in securityChild.ChildNodes)
                            {
                                if (transportChild.Name == "transport")
                                {
                                    foreach (XmlAttribute clientCredentialTypeAttribute in transportChild.Attributes)
                                    {
                                        if (clientCredentialTypeAttribute.Name == "clientCredentialType")
                                        {
                                            if (clientCredentialTypeAttribute.Value == "Basic")
                                            {
                                                AuthOptions = AuthenticationOptions.Basic_Authentication;
                                            }
                                            if (clientCredentialTypeAttribute.Value == "Windows")
                                            {
                                                AuthOptions = AuthenticationOptions.Windows_Authentication;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            XmlNodeList locationList = doc.GetElementsByTagName("location");
            if (locationList.Count > 0 && locationList[0].ParentNode.Name == "configuration")
            {
                SSOEnabled = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
