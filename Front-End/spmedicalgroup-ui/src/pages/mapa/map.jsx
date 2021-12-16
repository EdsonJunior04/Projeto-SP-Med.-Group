import { Map, Marker, GoogleApiWrapper, InfoWindow } from 'google-maps-react';
import { Component } from "react";
import logo from '../../Assets/img/Sp Medical Grouplogo.svg';
import { Link } from "react-router-dom";
import api from '../../services/api';

class maps extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaLocalizacoes: [],
            showingInfoWindow: false,
            marcadorAtivo: {},
            lugar: {},
            active: false,
        }
    };

    BuscarLocalizacoes = () => {
        api("/Localizacoes", {
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
            showingInfoWindow: true,
            
        });

        toggleMode = () => {
            this.setState({ active: !this.state.active })
        }

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

                <header>
                    <div>
                        <div className={this.state.active ? "icon iconActive" : "icon"} onClick={this.toggleMode}>
                            <div className="hamburguer hamburguerIcon"></div>
                        </div>
                        <div className={this.state.active ? 'menu menuOpen ' : 'menu menuClose'}>
                            <div className='list '>
                                <ul className='listItems'>
                                    <Link className='Link' to=""><li>PERFIL</li></Link>
                                    <a className='Link' href="#cadastro"><li>CADASTRAR CONSULTA</li></a>
                                    <a className='Link' href="#lista"><li>LISTAR CONSULTAS</li></a>
                                    <Link className='Link' to="/mapa"><li>MAPAS</li></Link>
                                    <Link className='Link' to="/cadastrarMapa"><li>CADASTRAR LOCALIZAÇÃO</li></Link>
                                    <li><button className='btn_sair btn' onClick={this.logout} >Sair</button></li>
                                </ul>
                            </div>
                        </div>
                    </div>

                    <div className="container_header_paciente">
                        <Link to="/">
                            <img
                                src={logo}
                                className="icone_paciente"
                                alt="logo da Sp Medical Group"
                            />{' '}
                        </Link>

                        <div>
                            <p>ADIMINISRADOR</p>
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
    apiKey: ("AIzaSyBBZYzs6HaSyjeVDFe-6UuasHX7XSB3Z5E")
})(maps)