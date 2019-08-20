import React from 'react';
import { BarChart, CartesianGrid, XAxis, YAxis, Bar, Legend,Tooltip } from 'recharts';
import { getMockData } from '../shared/mock-data-service';

class BarChartDemo extends React.Component {
    state={
        data:[]
    };
    componentDidMount(){
            getMockData().
            then(data => this.setState({data}))
            .catch(err => console.log('error', err));
    }
    render() {
        return (
            <BarChart
                width={800}
                height={300}
                data={this.state.data}
                margin={{
                    top: 5, right: 30, left: 20, bottom: 5,
                }}
            >
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="name" />
                <YAxis />
                <Tooltip />
                <Legend />
                <Bar dataKey="a" fill="#8884d8" />
                <Bar dataKey="b" fill="#82ca9d" />
            </BarChart>
        );
    }
}

export default BarChartDemo;