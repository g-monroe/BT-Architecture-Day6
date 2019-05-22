import React, { CSSProperties } from 'react';
import { ISuperhero } from './types/Superhero.types';
import { Card, Tag } from 'antd';
import Title from 'antd/lib/typography/Title';

interface ISuperheroCardProps {
    superhero: ISuperhero;
}
class SuperheroCard extends React.Component<ISuperheroCardProps> {
    render() {
        const headerStyle:CSSProperties = {
            backgroundColor: this.props.superhero.primaryColor,
            color: this.props.superhero.secondaryColor,
            fontWeight: 'bolder',
            fontSize: 30
        }

        return (
            <Card title={this.props.superhero.superheroName} bordered={true}  headStyle={headerStyle} data-testid="defender-card">
                <p>Secret Identity: {this.props.superhero.secretIdentity}</p>
                <p>First Appearance: {this.props.superhero.yearOfAppearance}</p>
                <p>Age at Origin: {this.props.superhero.ageAtOrigin}</p>
                <p>Universe: {this.props.superhero.universe}</p>
                <p>Alien?: {this.props.superhero.isAlien}</p>
                {this.props.superhero.isAlien && <p>Planet of Origin: {this.props.superhero.planetOfOrigin}</p>}

                <Title level={4}>Origin Story:</Title>
                <p>{this.props.superhero.originStory}</p>

                <Title level={4}>Abilities:</Title>
                {
                    this.props.superhero.abilities &&
                    this.props.superhero.abilities.map((item, index) => (
                        <Tag key={index} closable={false}>{item}</Tag>
                    ))
                }
            </Card>
        );
    }
}

export default SuperheroCard;