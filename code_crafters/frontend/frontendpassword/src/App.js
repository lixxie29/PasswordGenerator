import React, { useState, useEffect } from 'react';
import Button from '@mui/material/Button';
import './App.css';
import axios from 'axios';

function App() {

    const [password, setPassword] = useState('');
    const [isValid, setIsValid] = useState(true);
    const [timeLeft, setTimeLeft] = useState(45);

    const generatepassword = async () => {
        try {
            const response = await axios.post('https://localhost:7074/api/generatepassword');
            setPassword(response.data);
            setIsValid(true);
            setTimeLeft(45);
        }
        catch (error) { console.error(error); }
    }

    const checkpasswordvalid = async () => {
        try {
            const response = await axios.post('https://localhost:7074/api/generatepassword/isvalid', { timeLeft: timeLeft });
            setIsValid(response.data.isValid);
        } catch (error) { console.error(error); }
    }

    useEffect(() => {
        const interval = setInterval(() => {
            setTimeLeft(prevTimeLeft => prevTimeLeft - 1);
        }, 1000);

        return () => clearInterval(interval);
    }, [])

    useEffect(() => {
        if (timeLeft <= 0) {
            setIsValid(false);
            setPassword('');
        } else { checkpasswordvalid(); }
    }, [timeLeft])

  return (
    <div className="App">
      <header className="App-header">
              <h1>Password Generator</h1>
              <div className="appcontents">
                  <h2> {password} </h2>
                  <Button onClick={generatepassword} disabled={isValid} variation="contained">Generate Password</Button>
                  <p> {isValid ? `time left: ${timeLeft} seconds` : `password expired`}</p>
          </div>
      </header>
    </div>
  );
}

export default App;
