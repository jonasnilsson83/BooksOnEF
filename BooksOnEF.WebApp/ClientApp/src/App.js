import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { BookList } from './components/BookList';
import { Counter } from './components/Counter';
import { BookDetail } from "./components/BookDetail";
import { BookInfo } from "./components/BookInfo";
import { AuthorInfo } from "./components/AuthorInfo";
import "bootstrap/dist/css/bootstrap.min.css";

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/counter' component={Counter} />
                <Route path='/bookList' component={BookList} />
                <Route path='/BookDetail' component={BookDetail} />
                <Route path='/BookInfo' component={BookInfo} />
                <Route path='/AuthorInfo' component={AuthorInfo} />
            </Layout>
        );
    }
}
