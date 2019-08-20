import React from 'react';
import ShowErrors from './ShowErrors';
import queryString from 'querystringify';

class UserForm extends React.Component {

    state = { name: '', email: '', submitted: false };
    validations = {
        name: {
            required: true,
            minlength: { requiredLength: 5 }
        }
    };

    saveData(e) {
        e.preventDefault();
        this.setState({submitted:true});
        console.log('form submitted', this.state);
    }

    render() {
        console.log('name',this.props.match.params.name);
        console.log('age',queryString.parse(this.props.location.search));
        return (
            <form onSubmit={(e) => this.saveData(e)}>
                <label>Name</label>
                <input type="text"
                    value={this.state.name}
                    onChange={(e) => this.setState({ name: e.currentTarget.value })} />
                <ShowErrors value={this.state.name} validations={this.validations.name} display={this.state.submitted} />
                <label>Email</label>
                <input type="text"
                    value={this.state.email}
                    onChange={(e) => this.setState({ email: e.currentTarget.value })} />
                <button>Submit</button>
            </form>
        )
    }
}
export default UserForm;