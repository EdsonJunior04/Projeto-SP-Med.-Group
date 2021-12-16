import { Map, Marker, GoogleApiWrapper, InfoWindow } from 'google-maps-react';
import { Component } from "react";
import logo from '../../Assets/img/Sp Medical Grouplogo.svg';
// import { Link } from "react-router-dom";
import api from '../../services/api';

class maps extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaLocalizacoes: [],
            showingInfoWindow: false,
            marcadorAtivo: {},
            lugar: {},
        }
    };

    BuscarLocalizacoes = () => {
        api("/Localizacoes",{
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    this.setState({ listaLocalizacoes: resposta.data });
                }
            }).catch(erro => console.log(erro))
    }

    cliqueMarcador = (props, marker, e) =>
        this.setState({
            lugar: props,
            marcadorAtivo: marker,
            showingInfoWindow: true
        });


    componentDidMount() {
        this.BuscarLocalizacoes()
    }
    logout = async () => {
        localStorage.removeItem('usuario-login');
        this.props.history.push('/');
    };

    render() {
        return (
            <div>
                <main>

                <header className=" container header_Home" id="header">
                <div className=" div_header container">
                    <div>
                        <a href="#header">
                            <img className="img_header" src={logo} alt="" />
                        </a>
                    </div>
                    <div className="org_heade_adm">
                        <a href="/">Home</a>
                        <a href="/admlistar">Consultas</a>
                        <a href="/admusuario">Cadastrar Usuario</a>
                        <a href="/adm">Adminitrador</a>


                    </div>
                </div>
            </header>

                    <Map google={this.props.google} zoom={12}
                        initialCenter={{
                            lat: -23.53642760296254,
                            lng: -46.64621432441258
                        }}>

                        {

                            this.state.listaLocalizacoes.map((item) => {

                                return (
                                    <Marker onClick={this.cliqueMarcador}
                                        id={item.id}
                                        name={item.nome}
                                        title={item.nome}
                                        position={{ lat: item.latitude, lng: item.longitude }} />
                                )
                            })
                        }

                        <InfoWindow
                            marker={this.state.marcadorAtivo}
                            visible={this.state.showingInfoWindow}>
                            <div>
                                <h1 style={{ fontSize: 14, color: "#82C0D9" }}>{this.state.lugar.name}</h1>
                            </div>
                        </InfoWindow>

                    </Map>
                </main>
            </div>
        )
    }

}

export default GoogleApiWrapper({
    apiKey: ("AIzaSyBMkmry7eDc01lkICfWmMrdv18FsX_oDOQ")
})(maps)