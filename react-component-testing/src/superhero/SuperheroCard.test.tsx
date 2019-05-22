import React from 'react';
import Enzyme from 'enzyme';
import EnzymeAdapter from 'enzyme-adapter-react-16';
import { setupWrapper, findElementByTestId } from '../testHelpers';
import { ReactElement } from 'react';
import SuperheroCard from './SuperheroCard';

Enzyme.configure({ adapter: new EnzymeAdapter() });

describe('SupheroCard Component Tests', () => {
    let superheroCard: ReactElement;
    const defaultSuperheroProp = {
        superheroID: 0,
        superheroName: 'spider-man',
        secretIdentity: ''
    };

    beforeEach(() => {
        superheroCard = <SuperheroCard superhero={defaultSuperheroProp} />;
    })

    it('displays correct superhero name', () => {
        const wrapper = setupWrapper(superheroCard);
        const defenderCard = findElementByTestId(wrapper, 'superhero-card');
        expect(defenderCard.prop('title')).toBe('spider-man');
    });
});