import React from 'react';
import './App.css';
import { Row, Col, Button } from 'antd';
import Title from 'antd/lib/typography/Title';
import { ISuperhero } from './superhero/types/Superhero.types';
import { IBattle } from './superhero/types/Battle.types';
import SuperheroCard from './superhero/SuperheroCard';
import SuperheroPicker from './superhero/SuperheroPicker';

interface IAppState {
  superheroOptions?: ISuperhero[];
  defender?: ISuperhero;
  attacker?: ISuperhero;
  result?: string;
}

interface IAppProps {
}

class App extends React.Component<IAppProps, IAppState> {
  state: IAppState = {
    // superheroOptions: [
    //   {
    //     SuperheroName: 'Spider-Man',
    //     SecretIdentity: 'Peter Parker',
    //     AgeAtOrigin: 15,
    //     YearOfAppearance: 1962,
    //     OriginStory: 'Where do I start...',
    //     PrimaryColor: 'red',
    //     SecondaryColor: 'blue',
    //     Abilities: [
    //       {
    //         AbilityID: 1,
    //         Name: 'Strength'
    //       },
    //       {
    //         AbilityID: 2,
    //         Name: 'Jumping'
    //       }
    //     ]
    //   },
    //   {
    //     SuperheroName: 'Wolverine',
    //     SecretIdentity: 'Logan',
    //     YearOfAppearance: 1974,
    //     OriginStory: 'Bone claws replaced with adamantium',
    //     PrimaryColor: 'yellow',
    //     SecondaryColor: 'blue',
    //     Abilities: [
    //       {
    //         AbilityID: 3,
    //         Name: 'Healing'
    //       },
    //       {
    //         AbilityID: 4,
    //         Name: 'Berserker'
    //       }
    //     ]
    //   }
    // ]
  };

  componentDidMount = async () => {
    const requestOptions: RequestInit = {
      method: 'GET',
      headers: {
        "Content-Type": "application/json",
        'Access-Control-Allow-Origin': '*'
      },
      mode: "cors"
    };

    fetch('http://localhost:63252/api/superheroes', requestOptions)
      .then(response => {
        return response.json().then(responseJson => {
          this.setState({ ...this.state, superheroOptions: responseJson });
        });
      });
  }

  render() {
    return (
      <div className='App' data-testid='app-component'>
        {
          this.state.superheroOptions &&
          <Row>
            <Col span={10}>
              <SuperheroPicker superheroOptions={this.state.superheroOptions} title='attacker' onChange={newHero => this.setState({ ...this.state, defender: newHero })} />
            </Col>
            <Col span={4} />
            <Col span={10}          >
              <SuperheroPicker superheroOptions={this.state.superheroOptions} title='defender' onChange={newHero => this.setState({ ...this.state, attacker: newHero })} />
            </Col>
          </Row>
        }
        <Row>
          <Col span={10}>
            {this.state.defender && <SuperheroCard superhero={this.state.defender} />}
          </Col>

          <Col span={4}>
            <Title level={1} style={{ alignContent: 'center', verticalAlign: 'center' }}>VS</Title>
          </Col>

          <Col span={10}>
            {this.state.attacker && <SuperheroCard superhero={this.state.attacker} />}
          </Col>
        </Row>

        {
          this.state.defender &&
          this.state.attacker &&
          <Button type='danger' block onClick={async () => await this.handleFight()}>FIGHT!</Button>
        }

        {
          this.state.result &&
          <Title level={1}>{this.state.result}</Title>
        }
      </div>
    )
  }

  handleFight = () => {
    if (this.state.defender && this.state.attacker && this.state.superheroOptions) {
      const battle: IBattle = {
        attackerID: this.state.attacker!.superheroID,
        defenderID: this.state.defender!.superheroID,
        hasBattled: false
      }

      const requestOptions: RequestInit = {
        method: 'POST',
        headers: {
          "Content-Type": "application/json",
          'Access-Control-Allow-Origin': '*'
        },
        mode: "cors",
        body: JSON.stringify(battle)
      };

      fetch('http://localhost:63252/api/battles/fight', requestOptions)
        .then(response => {
          return response.json().then(responseJson => {
            let resultText: string = "Fighting...";
            if (!responseJson.winnerID) {
              resultText = "Draw";
            }
            else {
              const winner = this.state.superheroOptions!.find(s => s.superheroID === responseJson.winnerID)
              if (winner) {
                resultText = `${winner.superheroName} is the winner!`;
              }
            }
            this.setState({ ...this.state, result: resultText }); 
          });
        });
    }
  }
}

export default App;
