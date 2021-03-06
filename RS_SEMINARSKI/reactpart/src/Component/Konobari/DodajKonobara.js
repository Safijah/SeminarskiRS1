import axios from 'axios';
import React, { Component } from 'react'
import './DodajUrediKonobara.css'
class DodajKonobara extends Component {
    constructor(props) {
        super(props);
        this.state = {
            ImeKonobara: "",
            PrezimeKonobara: "",
            PlataKonobara: 0,
        }
        this.handleImeKonobara = this.handleImeKonobara.bind(this);
        this.handlePrezimeKonobara = this.handlePrezimeKonobara.bind(this);
        this.handlePlataKonobara = this.handlePlataKonobara.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleImeKonobara(event) {
        this.setState({ ImeKonobara: event.target.value });
    }
    handlePrezimeKonobara(event) {
        this.setState({ PrezimeKonobara: event.target.value });
    }
    handlePlataKonobara(event) {
        this.setState({ PlataKonobara: parseInt(event.target.value) });
    }

    handleSubmit(event) {
        event.preventDefault();
        console.log(this.state);

        axios.post("https://localhost:44367/KonobarApi", this.state)
            .then(function (response) {
                console.log(response);
            })
        // this.props.history.replace({ pathname: '/konobari' });


    }
    konobari = () => {
        console.log(this.props);
        this.props.history.replace({ pathname: '/konobari' })

    }
    kuhari = () => {
        this.props.history.replace({ pathname: '/kuhari' })

    }
    rezervacije = () => {
        this.props.history.replace({ pathname: '/rezervacije' })

    }

    render() {

        return <div>
            <div className="flexx">
                <button className="button" onClick={this.konobari}>Konobari</button>
                <button className="button" onClick={this.kuhari}>Kuhari</button>
                <button className="button" onClick={this.rezervacije}>Rezervacije</button>
            </div>
            <button onClick={() => { this.props.history.goBack() }} className="button">Prethodno</button>

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
                        <input type="text" className="input_polje" value={this.state.PrezimeKonobara} onChange={this.handlePrezimeKonobara} />
                    </div>
                    <div>
                        <label>Plata</label>
                        <input type="number" className="input_polje" value={this.state.PlataKonobara} onChange={this.handlePlataKonobara} />
                    </div>
                    <input type="submit" value="Submit" id="Submit" />
                </form >
            </div >
        </div>
    }
}

export default DodajKonobara;