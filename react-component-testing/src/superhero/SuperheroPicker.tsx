import React from 'react';
import { Select } from 'antd';
import { ISuperhero } from './types/Superhero.types';

interface ISuperheroPickerProps {
    superheroOptions: ISuperhero[];
    onChange: (newValue: ISuperhero) => void;
    title: string;
}

class SuperheroPicker extends React.Component<ISuperheroPickerProps> {
    render() {
        return (
            <Select defaultValue={`Pick the ${this.props.title}...`} style={{ width: '100%' }} onChange={(newValue: string) => this.onSuperheroChanged(newValue)}>
                {
                    this.props.superheroOptions.map((item, index) =>
                        <Select.Option key={index} value={item.SuperheroName}>{item.SuperheroName}</Select.Option>
                    )
                }
            </Select>
        )
    }

    onSuperheroChanged = (newValue: string): void => {
        let selectedSuperhero: ISuperhero | undefined;
        selectedSuperhero = this.props.superheroOptions.find(item => item.SuperheroName === newValue);
        if (selectedSuperhero) {
            this.props.onChange(selectedSuperhero);
        }
    }
}

export default SuperheroPicker;