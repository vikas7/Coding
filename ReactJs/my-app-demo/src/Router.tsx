import React from 'react';

import {Route, Switch} from 'react-router-dom';
import Login from './User/Components/login'
import LineChartsDemo from './Charts/Containers/LineChartDemo';
import BarChartsDemo from './Charts/Containers/BarChartsDemo';
import PieChartsDemo from './Charts/Containers/PieChartsDemo';
import PrivateRoute from './PrivateRouter';


const routes =[
    {path:'/login', component:Login},
    {path:'/charts/line',component:LineChartsDemo, auth:true},
    {path:'/charts/bar',component:BarChartsDemo},
    {path:'/charts/pie',component:PieChartsDemo},
]

const AppRouter : React.FC = (props) =>{
    return (
        <Switch>
            {routes.map(
                route =>route.auth?<PrivateRoute path={route.path} component={route.component}/>
                :<Route path={route.path} component={route.component}/>
            )}
        </Switch>
    )
}

export default AppRouter;