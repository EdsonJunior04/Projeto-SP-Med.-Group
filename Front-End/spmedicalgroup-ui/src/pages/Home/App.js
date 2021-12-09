import { Component } from "react";
import axios from "axios";
import { parseJwt } from "../../services/auth";

import '../../Assets/CSS/login.css';

import logo from '../../Assets/img/Sp Medical Grouplogo.svg';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            erroMensagem: '',
            isLoading: false,
        };
    }

    efetuarLogin = (evento) => {
        evento.preventDefault();
        this.setState({ erroMensagem: '', isLoading: true })
        axios.post('http://localhost:5000/api/Login', {
            emailUsuario: this.state.email,
            senhaUsuario: this.state.senha,
        })
            .then((resposta) => {
                if (resposta.status === 200) {
                    localStorage.setItem('usuario-login', resposta.data.token);
                    this.setState({ isLoading: false });
                    //   let base64 = localStorage.getItem('usuario-login').split('.')[1];
                    //   console.log(base64);
                    console.log(this.props);
                    console.log(parseJwt().role)
                    console.log(parseJwt())
                    if (parseJwt().role === '1') {
                        this.props.history.push('/medicos')
                    } else if (parseJwt().role === '2') {
                        this.props.history.push('/paciente')
                    } else if (parseJwt().role === '3') {
                        this.props.history.push('/consultasAdm')
                    }
                }
            })
            .catch(() => {
                this.setState({
                    erroMensagem: 'E-mail e/ou senha estão inválidos',
                    isLoading: false,
                })
            })
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    }



    render() {
        return (
            <div className="fundo_login">
                <main>
                    <div className="center-login">


                        <img
                            src={logo}
                            className="icone__login"
                            alt="logo da Sp Medical Group"
                        />{' '}

                        <form onSubmit={this.efetuarLogin}>
                            <div className="center-login">


                                <input
                                    className="input_login"
                                    type="text"
                                    name="email"
                                    value={this.state.email}
                                    placeholder=" E-mail"
                                    onChange={this.atualizaStateCampo}
                                />

                                <input
                                    className="input_login"
                                    type="password"
                                    name="senha"
                                    value={this.state.senhaUsuario}
                                    placeholder=" senha"
                                    onChange={this.atualizaStateCampo}
                                />
                                {
                                    this.state.isLoading === true && (
                                        <button
                                            type="submit"
                                            disabled
                                            className="btn_login"
                                            id="btn_login"
                                        >
                                            Loading...
                                        </button>
                                    )
                                }

                                {
                                    // Caso seja false, renderiza o botão habilitado com o texto 'Login'
                                    this.state.isLoading === false && (
                                        <button
                                            className="btn_login"
                                            id="btn_login"
                                            type="submit"
                                            disabled={
                                                this.state.email === '' || this.state.senha === ''
                                                    ? 'none'
                                                    : ''
                                            }
                                        >
                                            Login
                                        </button>
                                    )
                                }
                            </div>
                        </form>
                    </div>
                </main>
            </div>
        )
    }
}