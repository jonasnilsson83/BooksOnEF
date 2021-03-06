﻿import React, { Component } from 'react';
import * as Constants from '../Constants';
import BookDetail from "./BookDetail";

export class AuthorInfo extends Component {
    constructor(props) {
        super(props);
        this.state = {
            auhtorId: null,
            loading: true,
            books: {},
            showDetails: false, 
            selectedBookId: null 
        };
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick(value) {
        const newBookId = value.id;
        const newShow = !this.state.showDetails;

        this.setState({
            showDetails: newShow,
            selectedBookId: newBookId
        });
    }

    componentDidMount() {
        var idToUse;

        if (this.props.location.authorInfoProps != undefined) {
            idToUse = this.props.location.authorInfoProps.authorId;
        }
        else {
            var pathname = window.location.pathname,
                part = pathname.substr(pathname.lastIndexOf('/') + 1);

            if (part != undefined && !isNaN(part)) {
                idToUse = part;
            }
        }

        this.setState({ auhtorId: idToUse }, () => this.getAuthorData());
    }


    render() {
        const showDetails = this.state.showDetails;
        if (this.state.loading) {
            return <p><em>Loading...</em></p>;
        }

        if (this.state.auhtorId == undefined) {
            return <p><em>Something went wrong...</em></p>;
        }

        return (
            <div>
                <h1>{this.state.books[0].author.firstName + ' ' + this.state.books[0].author.lastName}</h1>

                {
                    showDetails ? (
                        <BookDetail onClose={this.state.showDetails} show={this.state.showDetails} bookId={this.state.selectedBookId} onClick={e => this.handleChildClick(e)} />
                    ) : ""
                }
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Price</th>
                            <th>Nbr in stock</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>

                        {

                            this.state.books.map(book =>
                                <tr key={book.id} >
                                    <td onClick={() => this.handleClick(book)} >{book.title}</td>
                                    <td>{book.price}</td>
                                    <td>{book.nbrInStock}</td>
                                    <td>

                                        <svg onClick={() => this.handleClick(book)} xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-info-circle" viewBox="0 0 16 16">
                                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"></path>
                                            <path d="M8.93 6.588l-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533L8.93 6.588zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0z"></path>
                                        </svg>


                                    </td>

                                </tr>
                            )}
                    </tbody>
                </table>

            </div>
        )
    }

    async getAuthorData() {

        const response = await fetch(Constants.UTL_Get_BooksByAuthor(this.state.auhtorId));
        const data = await response.json();
        this.setState({ books: data, loading: false, showDetails: false });
    }

}