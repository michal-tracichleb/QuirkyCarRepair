import React from 'react';
import InputMask from 'react-input-mask';

const PhoneNumberInput = ({ value, onBlur, className, onChange}) => {
    return (
        <InputMask
            mask="+48999999999"
            maskChar=""
            value={value}
            onBlur={onBlur}
            onChange={onChange}
        >
            {(inputProps) => (
                <input
                    {...inputProps}
                    type="tel"
                    name="phoneNumber"
                    className={className}
                />
            )}
        </InputMask>
    );
};

export default PhoneNumberInput;