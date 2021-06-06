import React from 'react'
import Tabela from '../../../Container/Tabela';
import Kuhari from '../../Kuhari/Kuhari';
import Konobari from '../../Konobari/Konobari';
import DodajUrediKuhara from '../../Kuhari/DodajUrediKuhara';
import { Route } from 'react-router';
import DodajUrediKonobara from '../../Konobari/DodajUrediKonobara';
import DodajUredi from '../DodajUredi';

const Main=()=>{
    return(
        <div>
{/* <Tabela/> */}
{/* <DodajUrediKuhara/> */}
<Route path='/kuhari' component={Kuhari} exact/>
<Route path='/kuhari/editkuhar/:id' component={DodajUrediKuhara}/>
<Route path='/konobari' component={Konobari} exact/>
<Route path='/konobari/editkonobar/:id' component={DodajUrediKonobara}/>

<Route path='/rezervacije' component={Tabela} exact/>
<Route path='/rezervacije/editrezervacije/:id' component={DodajUredi}/>
        </div>
    )
    
}
export default Main;