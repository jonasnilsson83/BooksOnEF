import React, { Component } from 'react';
import BookDetail from "./BookDetail";
import "../Modal.css";

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { books: [], loading: true, showDetails: false };
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick(value) {
        //alert('hi');

        this.setState(state => ({
            showDetails: !state.showDetails
        }));


    }

    componentDidMount() {
        this.getBookData();
    }


    render() {
        if (this.state.loading) {
            return <p><em>Loading...</em></p>;
        }
        else
            return (
                <div>
                    <h1 id="tabelLabel" >Book list</h1>
                    <p>List all books in store.</p>

                    <div >


                        <table className='table table-striped' aria-labelledby="tabelLabel">
                            <thead>
                                <tr>
                                    <th>Title</th>
                                    <th>Price</th>
                                    <th>Nbr in stock</th>
                                    <th>Test</th>
                                    <th>Debug</th>
                                </tr>
                            </thead>
                            <tbody>

                                {

                                    this.state.books.map(book =>
                                        <tr key={book.id} >
                                            <td>{book.title}</td>
                                            <td>{book.price}</td>
                                            <td>{book.nbrInStock}</td>
                                            <td> <button onClick={() => this.handleClick(this)}>
                                                {book.id == 52 ? 'ON' : 'OFF'}
                                            </button> </td>
                                            <td>
                                                <div >
                                                    //{this.state.showDetails && book.id == 52 ? <BookDetail bookId={book.id} /> : ""}
                                                    {this.state.showDetails && book.id == 52 ? <BookDetail onClose={this.state.showDetails} show={this.state.showDetails} bookId={book.id} /> : ""}
                                                </div>
                                            </td>

                                        </tr>
                                    )}
                            </tbody>
                        </table>

                    </div>

                </div>
            );
    }

    async getBookData() {
        //const response = await fetch('weatherforecast');
        const response = await fetch('https://localhost:44396/api/books');
        const data = await response.json();
        this.setState({ books: data, loading: false, showDetails: false });
    }
}