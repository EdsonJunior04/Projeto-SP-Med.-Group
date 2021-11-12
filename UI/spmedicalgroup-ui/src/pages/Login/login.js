
import { Component } from "react";
import axios from "axios";
import { parseJwt, usuarioAutenticado } from "../../services/auth";
import { Link } from "react-router-dom";

// import logo from "../../Assets/img/logo.png";

export default class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email: '',
            senha: '',
            erroMensagem: '',
            isLoading: false,
        };
    }

    // Função que faz a chamada para a API para realizar o login
    efetuaLogin = (event) => {
        //ignora o comportamento padrão do navegador (recarregar a página, por exemplo)
        event.preventDefault();

        this.setState({erroMensagem: '', isLoading: true});

        axios
        .post('http://localhost:5000/api/Login', {
            email: '',
            senha: '',
        })
    }

    render(){
        return(
            <div>
                <main>
                    <div>
                        <div>
                        {/* <img 
                        src={logo} 
                        className=""
                        alt= "logo do SpMedicalGroup"
                        /> */}
                        <h1>login   </h1>
                        </div>
                    </div>
                </main>
            </div>
        )
    }
}