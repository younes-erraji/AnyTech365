<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\BooksController;

Route::get("/books", [BooksController::class, 'books']);
Route::get("/book/{book}", [BooksController::class, 'book']);
Route::post("/book", [BooksController::class, 'saveBook']);
Route::post("/book/delete", [BooksController::class, 'deleteBook']);
Route::post("/book/update", [BooksController::class, 'updateBook']);
