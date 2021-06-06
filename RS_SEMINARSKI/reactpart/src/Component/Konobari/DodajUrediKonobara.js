import axios from 'axios';
import React, { Component } from 'react'
import Kuhari from '../Kuhari/Kuhari';
import './DodajUrediKonobara.css'
import Konobari from './Konobari';
class DodajUrediKonobara extends Component {
    constructor(props){
        super(props);
    this.state = {
        KonobarID:"",
        ImeKonobara: "",
        PrezimeKonobara: "",
        PlataKonobara: "",
        
        

    }
    this.handleImeKonobara = this.handleImeKonobara.bind(this);
    this.handlePrezimeKonobara = this.handlePrezimeKonobara.bind(this);
    this.handlePlataKonobara = this.handlePlataKonobara.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);



}
    handleImeKonobara(event) {
        this.setState({ImeKonobara:event.target.value});
      } 
      handlePrezimeKonobara(event) {
        this.setState({PrezimeKonobara:event.target.value});
      } 
      handlePlataKonobara(event) {
        this.setState({EPlataKonobara:event.target.value});
      }  
      
      handleSubmit(event){
        event.preventDefault();
        console.log(this.state);
       
        // axios.post("https://localhost:44367/AdminApi", this.state)
        //   .then(function (response) {
        //     console.log(response);
        //   })

          axios.put("https://localhost:44367/KonobarApi",this.state)
              .then(function (response) {
                  console.log(response);
              })

      }
    konobari=()=>{
        console.log(this.props);
            this.props.history.replace({pathname: '/konobari'})

      }
    kuhari=()=>{
        this.props.history.replace({pathname: '/kuhari'})

  }
  rezervacije=()=>{
    this.props.history.replace({pathname: '/rezervacije'})

}
      componentDidMount(){
        
        axios.get("https://localhost:44367/KonobarApi/"+this.props.match.params.id).then(result=>(
            this.setState({
                KonobarID:result.data.konobarID,
                ImeKonobara:result.data.imeKonobara,
                PrezimeKonobara:result.data.prezimeKonobara,
                PlataKonobara:result.data.plataKonobara
            })
        ));
      }
      render() {

        return <div>
            <div className="flexx">
            <button className="button" onClick={this.konobari}>Konobari</button>
            <button className="button" onClick={this.kuhari}>Kuhari</button>
            <button className="button" onClick={this.rezervacije}>Rezervacije</button>
            </div>
                  <button onClick={()=>{this.props.history.goBack()}} className="button">Prethodno</button>

            <div id="Pocetna">
                <div id="Slika">
                </div>
                <form onSubmit={this.handleSubmit}>
                    <div>
                        <label>Ime</label>
                        <input type="text" className="input_polje" value={this.state.ImeKonobara} onChange={this.handleImeKonobara} />
                    </div>
                    <div>
                        <label>PrezimeKonobara</label>
                        <input type="text" className="input_polje" value={this.state.PrezimeKonobara} onChange={this.handlePrezimeKonobara}/>
                    </div>
                    <div>
                        <label>Plata</label>
                        <input type="text" className="input_polje" value={this.state.PlataKonobara} onChange={this.handlePlataKonobara}/>
                    </div>
                    
                    <input type="submit" value="Submit" id="Submit"/>
                </form >
            </div >
        </div>
    }
}

export default DodajUrediKonobara;