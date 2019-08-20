// src/shared/components/PrivateRoute.tsx
import React from "react";
import { Route, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';

const PrivateRoute = ({ component: Comp, ...rest }) => {
    const { isAuthenticated } = rest;
    console.log(isAuthenticated);
    return (
        <Route
            {...rest} render={(props: any) =>
                isAuthenticated ? (
                    <Comp {...props} />
                ) : (
                        <Redirect
                            to={{
                                pathname: "/login",
                                state: { from: props.location }
                            }}
                        />
                    )
            }
        />
    );
}
const mapStateToProps = (state: any) => ({
    isAuthenticated: !!state.user.idToken
})
export default connect(mapStateToProps)(PrivateRoute);