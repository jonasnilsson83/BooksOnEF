import React, { Component } from 'react';
import { Button, Modal } from 'react-bootstrap'
import { Link } from "react-router-dom";
import * as Constants from '../Constants';

export class BookDetail extends Component {
    constructor(props) {
        super(props);
        this.state = {
            bookDetail: {}, loading: true
        };
    }

    componentDidMount() {
        this.populateBookDetail();
    }

    static renderBookTable(book) {
        
        if (book == undefined) {
            return "";
        }

        return (
            <div >
                <table className='table table-striped' aria-labelledby="tableLabel">
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Author</th>
                            <th>Price</th>
                            <th>Nbr in stock</th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr key={book.id} >
                            <td>{book.title}</td>
                            <td>{book.author.firstName + book.author.lastName}</td>
                            <td>{book.price}</td>
                            <td>{book.nbrInStock}</td>
                        </tr>
                    </tbody>
                </table>

            </div>
        );
    }

    render() {

        if (!this.props.show) {
            return null;
        }

        const contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : BookDetail.renderBookTable(this.state.bookDetail);

        return (

            <Modal show={this.props.show} dialogClassName="" aria-labelledby="example-custom-modal-styling-title" >
                <Modal.Header closeButton>
                    <Modal.Title>Book info</Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    {contents}

                </Modal.Body>

                <Modal.Footer>
                    <Link
                        to={{
                            pathname: "/bookInfo",
                            bookInfoProps: {
                                bookId: this.props.bookId
                            }
                        }}>
                        <Button variant="secondary">Get more details</Button>
                    </Link>

                    <Button variant="secondary" onClick={this.props.onClick}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal >
        );
    }

    async populateBookDetail() {

        if (this.props.bookId == null) {
            return;
        }

        const response = await fetch(Constants.URL_Get_Books(this.props.bookId));

        if (!response.ok) {
            return;
        }

        const data = await response.json();
        this.setState({ bookDetail: data, loading: false });
    }
}
export default BookDetail;