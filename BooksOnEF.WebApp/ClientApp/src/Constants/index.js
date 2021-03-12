const APIURL = 'https://localhost:44396/api/';
const APIURL_BOOKS_OptionalId = APIURL + 'books/';
const APiURL_GetAllBooksByAuthor = APIURL + 'books/author/';

export function URL_Get_Books(optionalId) {

    return optionalId == undefined ?
        APIURL_BOOKS_OptionalId :
        APIURL_BOOKS_OptionalId + optionalId;
}


export function UTL_Get_BooksByAuthor(authorId) {
    return APiURL_GetAllBooksByAuthor + authorId;
}