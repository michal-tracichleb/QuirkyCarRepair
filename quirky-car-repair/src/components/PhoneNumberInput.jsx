import React from 'react';
import InputMask from 'react-input-mask';

const PhoneNumberInput = ({ value, onBlur, className}) => {
    return (
        <InputMask
            mask="+48 999-999-999"
            maskChar=""
            value={value}
            onBlur={onBlur}
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