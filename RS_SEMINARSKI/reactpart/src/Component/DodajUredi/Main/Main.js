import React from 'react'
import Tabela from '../../../Container/Tabela';
import Kuhari from '../../Kuhari/Kuhari';
import Konobari from '../../Konobari/Konobari';
import DodajUrediKuhara from '../../Kuhari/DodajUrediKuhara';
import { Route } from 'react-router';
import DodajUrediKonobara from '../../Konobari/DodajUrediKonobara';
import DodajUredi from '../DodajUredi';
import DodajRezervaciju from '../DodajRezervaciju';
import DodajKonobara from '../../Konobari/DodajKonobara'
const Main=()=>{
    return(
        <div>
{/* <Tabela/> */}
{/* <DodajUrediKuhara/> */}
<Route path='/kuhari' component={Kuhari} exact/>
<Route path='/kuhari/editkuhar/:id' component={DodajUrediKuhara}/>
<Route path='/konobari/dodajnovogkonobara' component={DodajKonobara}/>
<Route path='/konobari' component={Konobari} exact/>
<Route path='/konobari/editkonobar/:id' component={DodajUrediKonobara}/>

<Route path='/rezervacije' component={Tabela} exact/>
<Route path='/rezervacije/editrezervacije/:id' component={DodajUredi}/>
<Route path='/rezervacije/dodajrezervaciju' component={DodajRezervaciju}/>

        </div>
    )
    
}
export default Main;