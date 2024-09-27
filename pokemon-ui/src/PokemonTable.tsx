import React from 'react';


const PokemonTable: React.FC = () =>{
    return (
        <table className="table">
            <thead>
            <tr>
                <th scope="col">Number</th>
                <th scope="col">Name</th>
                <th scope="col">Generation</th>
                <th scope="col">Height</th>
                <th scope="col">Weight</th>
                <th scope="col">Type 1</th>
                <th scope="col">Type 2</th>
                <th scope="col">Move Count</th>
            </tr>
            </thead>
            <tbody>
            <tr>
                <th scope="row">1</th>
                <td>Mark</td>
                <td>Otto</td>
                <td>@mdo</td>
            </tr>
            <tr>
                <th scope="row">2</th>
                <td>Jacob</td>
                <td>Thornton</td>
                <td>@fat</td>
            </tr>
            <tr>
                <th scope="row">3</th>
                <td>Larry the Bird</td>
                <td>@twitter</td>
            </tr>
            </tbody>
        </table>
    );
}
 export default PokemonTable;