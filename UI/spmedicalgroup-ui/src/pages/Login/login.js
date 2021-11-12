
import { Component } from "react";
import axios from "axios";
import { parseJwt, usuarioAutenticado } from "../../services/auth";
import { Link } from "react-router-dom";

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

    // // Função que faz a chamada para a API para realizar o login
    // efetuaLogin = (event) => {
    //     //ignora o comportamento padrão do navegador (recarregar a página, por exemplo)
    //     event.preventDefault();

    //     this.setState({ erroMensagem: '', isLoading: true });

    //     axios
    //         .post('http://localhost:5000/api/Login', {
    //             email: '',
    //             senha: '',
    //         })

    //         //Recebe todo o conteúdo da resposta da requisição  na variável resposta
    //         .then((resposta) => {
    //             //verifico se o status code dessa resposta é igual a 200 
    //             if (resposta.status === 200) {
    //                 //se sim, exibe no console do navegador o token usuário logado,
    //                 //console.log ('Mu token é: ' + resposta.data.token);
    //                 //salva o valor  do token  no localStorage

    //                 localStorage.setItem('usuario-login', resposta.data.token);
    //                 // e define que a requisição terminou
    //                 this.setState({ isLoading: false });

    //                 //define variável base64 que vai receber o payload do token
    //                 let base64 = localStorage.getItem('usuario-login').split('.')[1];
    //                 //exibe no console do navegador o valor em base64
    //                 console.log(base64);

    //                 // exibe no console o valor decodificado de base64 para string
    //                 // console.log(window.atob(base64));

    //                 // exibe no console do navegador o valor da chave role
    //                 // console.log( JSON.parse( window.atob(base64) ) );

    //                 // console.log( parseJwt().role );

    //                 // exibe as propriedades da página
    //                 console.log(this.props);
    //                 //verifique se o usuario logado é do tipo administrador
    //                 if (parseJWT().role === '1') {
    //                     this.props.history.push('/consultas');
    //                     console.log('Estou logado: ' + usuarioAutenticado());
    //                 }else{
    //                     this.props.history.push('/')
    //                 }
    //             }
    //         })
    // }

    render() {
        return (
            <div className="fundo_login">
                <main>
                    <div className="center-login">

                        <Link to="/">
                            <img
                                src={logo}
                                className="icone__login"
                                alt="logo da Sp Medical Group"
                            />{' '}
                        </Link>

                        <input
                            className="input_login"
                            type="text"
                            name="email"
                            // value={this.state.email}
                            placeholder=" E-mail"
                        // onChange={  }
                        />

                        <input
                            className="input_login"
                            type="password"
                            name="password"
                            // value={this.state.senha}
                            placeholder=" senha"
                        // onChange={  }
                        />

                        <button
                            type="submit"
                            className="btn_login"
                        >
                            Logar
                        </button>
                    </div>
                </main>
            </div>
        )
    }
}