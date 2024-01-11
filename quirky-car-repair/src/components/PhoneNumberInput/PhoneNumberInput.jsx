import InputMask from 'react-input-mask';

const PhoneNumberInput = ({ value, onBlur, className, onChange, required}) => {
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
                    required={required}
                />
            )}
        </InputMask>
    );
};

export default PhoneNumberInput;