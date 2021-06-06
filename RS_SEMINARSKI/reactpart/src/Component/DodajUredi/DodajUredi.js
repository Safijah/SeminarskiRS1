import axios from 'axios';
import React, { Component } from 'react'
import './DodajUredi.css'
class DodajUredi extends Component {
    constructor(props){
        super(props);
    this.state = {
        KorisnikID:"",
        ImeKorisnika: "",
        PrezimeKorisnika: "",
        KorisnicnoIme: "",
        Email: "",
        

    }
    this.handleImeKorisnika = this.handleImeKorisnika.bind(this);
    this.handlePrezimeKorisnika = this.handlePrezimeKorisnika.bind(this);
    this.handleEmail = this.handleEmail.bind(this);
    this.handleKorisnicno = this.handleKorisnicno.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);



}
    handleImeKorisnika(event) {
        this.setState({ImeKorisnika:event.target.value});
      } 
      handlePrezimeKorisnika(event) {
        this.setState({PrezimeKorisnika:event.target.value});
      } 
      handleEmail(event) {
        this.setState({Email:event.target.value});
      }  
      handleKorisnicno(event) {
        this.setState({KorisnicnoIme:event.target.value});
      }
      handleSubmit(event){
        event.preventDefault();
        console.log(this.state);
       
        // axios.post("https://localhost:44367/AdminApi", this.state)
        //   .then(function (response) {
        //     console.log(response);
        //   })

          axios.put("https://localhost:44367/AdminApi",this.state)
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
        
        axios.get("https://localhost:44367/AdminApi/c249e795-9ecd-4fde-a8b9-460043d21a1e").then(result=>(
            this.setState({
                KorisnikID:result.data.korisnikID,
                ImeKorisnika:result.data.imeKorisnika,
                PrezimeKorisnika:result.data.prezimeKorisnika,
                KorisnicnoIme:" ",
                Email:result.data.email
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
                        <input type="text" className="input_polje" value={this.state.ImeKorisnika} onChange={this.handleImeKorisnika} />
                    </div>
                    <div>
                        <label>PrezimeKorisnika</label>
                        <input type="text" className="input_polje" value={this.state.PrezimeKorisnika} onChange={this.handlePrezimeKorisnika}/>
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