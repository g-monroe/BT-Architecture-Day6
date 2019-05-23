import React from 'react';
import Enzyme from 'enzyme';
import EnzymeAdapter from 'enzyme-adapter-react-16';
import { findElementByTestId, setupWrapper } from './testHelpers';
import App from './App';
import { ReactElement } from 'react';

Enzyme.configure({ adapter: new EnzymeAdapter() });

describe('App Component Tests', () => {
  let app: ReactElement;

  beforeEach(() => {
    app = <App />;
  })

  it('renders without crashing', () => {
    const appComponent = findElementByTestId(setupWrapper(app), 'app-component');
    expect(appComponent.length).toBe(1);
  });
});