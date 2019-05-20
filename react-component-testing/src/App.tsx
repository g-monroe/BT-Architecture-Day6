import React from 'react';
import './App.css';
import { Row, Col, Select } from 'antd';
import Title from 'antd/lib/typography/Title';
import { ISuperhero } from './superhero/types/Superhero.types';
import SuperheroCard from './superhero/SuperheroCard';

interface IAppState {
  superheroOptions: ISuperhero[];
  defender: ISuperhero;
  attacker: ISuperhero;
}

interface IAppProps {
}

class App extends React.Component<IAppProps, IAppState> {
  state: IAppState = {
    superheroOptions: [
      {
        SuperheroName: 'Spider-Man',
        SecretIdentity: 'Peter Parker',
        AgeAtOrigin: 15,
        YearOfAppearance: 1962,
        OriginStory: 'Where do I start...',
        Abilities: [
          {
            AbilityID: 1,
            Name: 'Strength'
          },
          {
            AbilityID: 2,
            Name: 'Jumping'
          }
        ]
      },
      {
        SuperheroName: 'Wolverine',
        SecretIdentity: 'Logan',
        YearOfAppearance: 1974,
        OriginStory: 'Bone claws replaced with adamantium',
        Abilities: [
          {
            AbilityID: 3,
            Name: 'Healing'
          },
          {
            AbilityID: 4,
            Name: 'Berserker'
          }
        ]
      }
    ],
    defender:
    {
      SuperheroName: 'Spider-Man',
      SecretIdentity: 'Peter Parker',
      AgeAtOrigin: 15,
      YearOfAppearance: 1962,
      OriginStory: 'Where do I start...',
      Abilities: [
        {
          AbilityID: 1,
          Name: 'Strength'
        },
        {
          AbilityID: 2,
          Name: 'Jumping'
        }
      ]
    },
    attacker: {
      SuperheroName: 'Wolverine',
      SecretIdentity: 'Logan',
      YearOfAppearance: 1974,
      OriginStory: 'Bone claws replaced with adamantium',
      Abilities: [
        {
          AbilityID: 3,
          Name: 'Healing'
        },
        {
          AbilityID: 4,
          Name: 'Berserker'
        }
      ]
    }
  };

  render() {
    return (
      <div className='App' data-testid='app-component'>
        <Row>
          <Col span={10}>
            <Select>
              {
                this.state.superheroOptions.map((item, index) => 
                <Select.Option key={item.SuperheroID} value={item.SuperheroName}>{item.SuperheroName}</Select.Option>
                )
              }
            </Select>
          </Col>
        </Row>
        <Row>
          <Col span={10}>
            <SuperheroCard superhero={this.state.defender} />
          </Col>

          <Col span={4}>
            <Title level={1}>VS</Title>
          </Col>

          <Col span={10}>
            <SuperheroCard superhero={this.state.attacker} />
          </Col>
        </Row>
      </div>
    )
  }
}

export default App;
