import React from 'react';

class Consultas extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas: [],
            titulo : ''
        };
    };

    componentDidMount(){
        //
    };

    render(){
        return(
            //JSX
            <div>
                <main>
                    {/* Lista de tipos de consulta */}
                    <section>
                        <h2>Lista de Consultas</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Consulta</th>
                                </tr>
                            </thead>
                            <tbody>

                            </tbody>
                        </table>
                    </section>
                    {/* Cadastro de tipos de consulta */}
                </main>
            </div>
        )
    }
};
export default Consultas;