import React from 'react';
import { PieChart, Pie, Tooltip } from 'recharts';
import { getMockData } from '../shared/mock-data-service';

class PieChartDemo extends React.Component {
    state = {
        data: []
    };
    componentDidMount() {
        getMockData().
            then(data => this.setState({ data }))
            .catch(err => console.log('error', err));
            console.log(this.state.data);
    }
    render() {
        return (
            <PieChart width={400} height={400}>
                <Pie dataKey="a" startAngle={180} endAngle={0} 
                data={this.state.data} cx={200} cy={200} 
                outerRadius={80} fill="#8884d8" label />
            </PieChart>
        );
    }
}

export default PieChartDemo;