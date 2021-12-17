import { React, Component } from 'react';
import api from '../../services/api';

export default class PerfilFoto extends Component {
  constructor(props) {
    super(props);
    this.state = { imagem64: '' };
  }

//   componentDidMount() {
//     this.buscarImagem();
//   }

  buscarImagem = () => {
    api('/Usuarios/imagem/bd', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
      },
    })
      .catch((erro) => console.log(erro))
      .then((resposta) => {
        if (resposta.status === 200) {
          console.log(resposta);
          this.setState({ imagem64: resposta.data });
        }
      });
  };

  render() {
    return (
      <img
        className="imagem-header"
        src={`data:image;base64,${this.state.imagem64}`}
        alt="Imagem de Perfil"
      />
    );
  }
}