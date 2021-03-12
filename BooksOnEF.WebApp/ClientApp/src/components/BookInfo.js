import React, { Component } from 'react';
import * as Constants from '../Constants';
import { Button } from 'react-bootstrap';
import { Link } from "react-router-dom";

export class BookInfo extends Component {

    constructor(props) {
        super(props);
        this.state = {
            bookId: null,
            loading: true,
            book: {}
        };
    }

    componentDidMount() {
        var idToUse = 0;

        if (this.props.location.bookInfoProps != undefined) {
            idToUse = this.props.location.bookInfoProps.bookId;
        }
        else {
            var pathname = window.location.pathname,
                part = pathname.substr(pathname.lastIndexOf('/') + 1);

            if (part != undefined) {
                idToUse = part;
            }
        }

        this.setState({ bookId: idToUse }, () => this.getBookData());
    }

    render() {

        if (this.state.loading) {
            return <p><em>Loading...</em></p>;
        }

        if (this.state.book.id == undefined) {
            return <p><em>Something went wrong...</em></p>;
        }

        return (
            <div>
                <h1>{this.state.book.title}</h1>

                <table className='table table-striped' aria-labelledby="tableLabel">
                    <tbody>
                        <tr>
                            <td>Title</td>
                            <td>{this.state.book.title}</td>
                        </tr>
                        <tr>
                            <td>Author</td>
                            <td>{this.state.book.author.firstName + ' ' + this.state.book.author.lastName}</td>
                        </tr>
                        <tr>
                            <td>Price</td>
                            <td>{this.state.book.price}</td>
                        </tr>
                        <tr>
                            <td>Nbr in stock</td>
                            <td>{this.state.book.nbrInStock}</td>
                        </tr>
                        <tr>
                            <td>Description</td>
                            <td>
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum
                            </td>
                        </tr>
                    </tbody>
                </table>

                <div>

                    <Link
                        to={{
                            pathname: "/AuthorInfo",
                            authorInfoProps: {
                                authorId: this.state.book.author.id
                            }
                        }}>
                        <Button variant="secondary">More from this author</Button>
                    </Link>

                </div>
            </div>

        );
    }



    async getBookData() {

        const response = await fetch(Constants.URL_Get_Books(this.state.bookId));

        if (response.status != 200) {
            this.setState({ loading: false, showDetails: false });
        }
        else {
            const data = await response.json();
            this.setState({ book: data, loading: false, showDetails: false });
        }
    }
}