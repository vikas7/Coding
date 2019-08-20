import React, { FormEvent } from 'react';
import { userLogin, userRegistration } from '../Services/user-service'
import { storeuser } from '../../_store/Actions/user-actions';
import { connect } from 'react-redux';

class Login extends React.Component {

    email: HTMLInputElement;
    password: HTMLInputElement;

    login = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        userLogin(this.email.value, this.password.value)
            .then(
                user => this.props['storeuser'](user)
            ).catch(
                err => console.log('error', err)
            )
    }

    register = () => {
        userRegistration(this.email.value, this.password.value)
            .then(
                user => this.props['storeuser'](user)
            ).catch(
                err => console.log('error', err)
            );
    }

    render() {
        return (
            <div className="col-md-4 offset-md-4 shadow mt-4 alert-info p-4">
                <h2>Login</h2>
                <form onSubmit={this.login}>
                    <div className="form-group">
                        <label>Email</label>
                        <input type="email" ref={(r) => this.email = r as HTMLInputElement} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label>Password</label>
                        <input type="password" ref={(r) => this.password = r as HTMLInputElement} className="form-control" />
                    </div>
                    <div className="form-group">
                        <button className="btn btn-success btn-sm">Submit</button>
                        <button type="button" onClick={this.register}
                            className="btn btn-secondary btn-sm">Register</button>
                    </div>
                </form>
            </div>
        )
    }
}

const mapDispatchToProps = (dispatch: any) => ({
    storeuser: (user: any) => dispatch(storeuser(user))
})
export default connect(null, mapDispatchToProps)(Login);