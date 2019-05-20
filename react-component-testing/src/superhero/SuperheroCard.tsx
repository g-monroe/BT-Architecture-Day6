import React from 'react';
import { ISuperhero } from './types/Superhero.types';
import { Card, List } from 'antd';
import Title from 'antd/lib/typography/Title';

interface ISuperheroCardProps {
    superhero: ISuperhero;
}
class SuperheroCard extends React.Component<ISuperheroCardProps> {
    defaultProps = {
        supehero: {
            SuperheroName: '',
            SecretIdentity: ''
        }
    }

    render() {
        return (
            <Card title={this.props.superhero.SuperheroName} bordered={true} data-testid="defender-card">
                <p>Secret Identity: {this.props.superhero.SecretIdentity}</p>
                <p>First Appearance: {this.props.superhero.YearOfAppearance}</p>
                <p>Age at Origin: {this.props.superhero.AgeAtOrigin}</p>
                <p>Universe: {this.props.superhero.Universe}</p>
                <p>Alien?: {this.props.superhero.IsAlien}</p>
                {this.props.superhero.IsAlien && <p>Planet of Origin: {this.props.superhero.PlanetOfOrigin}</p>}

                <Title level={2}>Origin Story:</Title>
                <p>{this.props.superhero.OriginStory}</p>

                <Title level={2}>Abilities:</Title>
                {
                    this.props.superhero.Abilities &&
                    <List 
                    dataSource={this.props.superhero.Abilities}
                     renderItem={item =>(
                         <List.Item>
                             * {item.Name}
                         </List.Item>
                     ) }>
                    </List>
                }
            </Card>
        );
    }
}

export default SuperheroCard;