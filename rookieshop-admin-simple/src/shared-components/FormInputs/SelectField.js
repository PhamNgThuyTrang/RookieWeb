import React from 'react';
import { useField } from 'formik';

const SelectField = (props) => {
    const [value , setValue] = useField(props);

    const { options, label, isrequired } = props;

    const handleChange = (e) => {
        setValue(e.target.value)
    };

    return (
        <>
            <div className="mb-3 row">
                <label className="col-4 col-form-label d-flex">
                    {label}
                    {isrequired && (
                        <div className="invalid ml-1"> (*)</div>
                    )}
                </label>

                <div className="col">
                    <select className="custom-select" onChange={handleChange}>
                        <option selected hidden>Open this select menu</option>
                        {
                            options.map(({ id, label: optionLabel, value: optionValue }) => (
                                <option key={id} value={optionValue} selected = {optionValue === value}>
                                    {optionLabel}
                                </option>
                            ))
                        }
                    </select>
                </div>
            </div>
        </>
    );
};
export default SelectField;
