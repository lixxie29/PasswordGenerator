import React, { useState } from 'react';
import axios from 'axios';

const PasswordForm = () => {
    const [otp, setOTP] = useState('');

    const generateOTP = async () => {
        try {
            const response = await axios.post('http://localhost:5000/api/generate');
            setOTP(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div>
            <button onClick={generateOTP}> Generate Password </button>
            {otp && <p> one time password: {otp}</p>}
        </div>
    );
};

export default PasswordForm;