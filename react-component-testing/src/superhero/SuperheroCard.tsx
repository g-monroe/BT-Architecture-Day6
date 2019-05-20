import React, { CSSProperties } from 'react';
import { ISuperhero } from './types/Superhero.types';
import { Card, Tag } from 'antd';
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
        const headerStyle:CSSProperties = {
            backgroundColor: this.props.superhero.PrimaryColor,
            color: this.props.superhero.SecondaryColor,
            fontWeight: 'bolder',
            fontSize: 30
        }

        return (
            <Card title={this.props.superhero.SuperheroName} bordered={true}  headStyle={headerStyle} data-testid="defender-card">
                <p>Secret Identity: {this.props.superhero.SecretIdentity}</p>
                <p>First Appearance: {this.props.superhero.YearOfAppearance}</p>
                <p>Age at Origin: {this.props.superhero.AgeAtOrigin}</p>
                <p>Universe: {this.props.superhero.Universe}</p>
                <p>Alien?: {this.props.superhero.IsAlien}</p>
                {this.props.superhero.IsAlien && <p>Planet of Origin: {this.props.superhero.PlanetOfOrigin}</p>}

                <Title level={4}>Origin Story:</Title>
                <p>{this.props.superhero.OriginStory}</p>

                <Title level={4}>Abilities:</Title>
                {
                    this.props.superhero.Abilities &&
                    this.props.superhero.Abilities.map(item => (
                        <Tag key={item.AbilityID} closable={false}>{item.Name}</Tag>
                    ))
                    // <List
                    //     bordered={false}
                    //     dataSource={this.props.superhero.Abilities}
                    //     renderItem={item => (
                    //         <List.Item key={item.AbilityID} itemType={'*'}>{item.Name}</List.Item>
                    //     )}>
                    // </List>
                }
            </Card>
        );
    }
}

export default SuperheroCard;