import React from 'react'
import Main from './Component/DodajUredi/Main/Main';
import {BrowserRouter} from 'react-router-dom'
function App() {
 
  return (
      <BrowserRouter>
    <div>
      <Main/>
    </div>
    </BrowserRouter>
  );
}

export default App;
