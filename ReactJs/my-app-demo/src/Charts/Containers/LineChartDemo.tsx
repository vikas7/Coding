import React from 'react';
import {
    LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend,
  } from 'recharts';

  import {getMockData} from '../shared/mock-data-service';

class LineChartDemo extends React.Component{
    state={
        data:[]
    };
    componentDidMount(){
            getMockData().
            then(data => this.setState({data}))
            .catch(err => console.log('error', err));
    }

    render(){
        return (
        <LineChart width={800} height={300} data={this.state.data}
        margin={{
          top: 5, right: 30, left: 20, bottom: 5,
        }}
      >
        <CartesianGrid strokeDasharray="3 3" />
        <XAxis dataKey="name" />
        <YAxis />
        <Tooltip />
        <Legend />
        <Line type="monotone" dataKey="a" stroke="#8884d8" />
        <Line type="monotone" dataKey="b" stroke="#82ca9d" />
        <Line type="monotone" dataKey="c" stroke="#000000" />
      </LineChart>
        );
    }
}

export default LineChartDemo;