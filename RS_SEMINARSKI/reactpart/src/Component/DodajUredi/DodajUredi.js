import axios from 'axios';
import React, { Component } from 'react'
import './DodajUredi.css'
class DodajUredi extends Component {
    constructor(props){
        super(props);
    this.state = {
       
        ime: "",
        prezime: "",
        KorisnicnoIme: "",
        Email: "",
        

    }
    this.handleIme = this.handleIme.bind(this);
    this.handlePrezime = this.handlePrezime.bind(this);
    this.handleEmail = this.handleEmail.bind(this);
    this.handleKorisnicno = this.handleKorisnicno.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);



}
    handleIme(event) {
        this.setState({ime:event.target.value});
      } 
      handlePrezime(event) {
        this.setState({prezime:event.target.value});
      } 
      handleEmail(event) {
        this.setState({Email:event.target.value});
      }  
      handleKorisnicno(event) {
        this.setState({KorisnicnoIme:event.target.value});
      }
      handleSubmit(event){
        event.preventDefault();


        axios.post("https://localhost:44367/AdminApi", this.state)
          .then(function (response) {
            console.log(response);
          })

      }
            
      componentDidMount(){
        // axios.get("https://localhost:44367/AdminApi/c249e795-9ecd-4fde-a8b9-460043d21a1e").then(result=>(
        //     this.setState({
        //         ime:result.data.imeKorisnika,
        //         prezime:result.data.prezimeKorisnika,
        //         KorisnicnoIme:" ",
        //         Email:result.data.email
        //     })
        // ));
      }
      render() {

        return <div>
            <div id="Pocetna">
                <div id="Slika">
                </div>
                <form onSubmit={this.handleSubmit}>
                    <div>
                        <label>Ime</label>
                        <input type="text" className="input_polje" value={this.state.ime} onChange={this.handleIme} />
                    </div>
                    <div>
                        <label>Prezime</label>
                        <input type="text" className="input_polje" value={this.state.prezime} onChange={this.handlePrezime}/>
                    </div>
                    <div>
                        <label>Email</label>
                        <input type="text" className="input_polje" value={this.state.Email} onChange={this.handleEmail}/>
                    </div>
                    <div>
                        <label>KorisnicnoIme</label>
                        <input type="text" className="input_polje" value={this.state.KorisnicnoIme} onChange={this.handleKorisnicno}/>
                    </div>
                    <input type="submit" value="Submit" id="Submit"/>
                </form >
            </div >
        </div>
    }
}

export default DodajUredi;