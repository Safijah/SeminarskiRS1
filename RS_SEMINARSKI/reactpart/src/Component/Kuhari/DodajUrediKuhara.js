import axios from 'axios';
import React, { Component } from 'react'
import './DodajUrediKuhara.css'
class DodajUrediKuhara extends Component {
    constructor(props){
        super(props);
    this.state = {
        KuharID:"",
        ImeKuhara: "",
        PrezimeKuhara: "",
        PlataKuhara: "",
        
        

    }
    this.handleImeKuhara = this.handleImeKuhara.bind(this);
    this.handlePrezimeKuhara = this.handlePrezimeKuhara.bind(this);
    this.handlePlataKuhara = this.handlePlataKuhara.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);



}
    handleImeKuhara(event) {
        this.setState({ImeKuhara:event.target.value});
      } 
      handlePrezimeKuhara(event) {
        this.setState({PrezimeKuhara:event.target.value});
      } 
      handlePlataKuhara(event) {
        this.setState({EPlataKuhara:event.target.value});
      }  
      
      handleSubmit(event){
        event.preventDefault();
        console.log(this.state);
       
        // axios.post("https://localhost:44367/AdminApi", this.state)
        //   .then(function (response) {
        //     console.log(response);
        //   })

          axios.put("https://localhost:44367/KuharApi",this.state)
              .then(function (response) {
                  console.log(response);
              })

      }
            
      componentDidMount(){
        
        axios.get("https://localhost:44367/KuharApi/1").then(result=>(
            this.setState({
                KuharID:result.data.kuharID,
                ImeKuhara:result.data.imeKuhara,
                PrezimeKuhara:result.data.prezimeKuhara,
                PlataKuhara:result.data.plataKuhara
            })
        ));
      }
      render() {

        return <div>
            <div id="Pocetna">
                <div id="Slika">
                </div>
                <form onSubmit={this.handleSubmit}>
                    <div>
                        <label>Ime</label>
                        <input type="text" className="input_polje" value={this.state.ImeKuhara} onChange={this.handleImeKuhara} />
                    </div>
                    <div>
                        <label>PrezimeKuhara</label>
                        <input type="text" className="input_polje" value={this.state.PrezimeKuhara} onChange={this.handlePrezimeKuhara}/>
                    </div>
                    <div>
                        <label>Plata</label>
                        <input type="text" className="input_polje" value={this.state.PlataKuhara} onChange={this.handlePlataKuhara}/>
                    </div>
                    
                    <input type="submit" value="Submit" id="Submit"/>
                </form >
            </div >
        </div>
    }
}

export default DodajUrediKuhara;