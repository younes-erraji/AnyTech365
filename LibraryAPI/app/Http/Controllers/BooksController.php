<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

use Illuminate\Support\Facades\Validator;

use App\Models\Book;

class BooksController extends Controller
{
    public function __construct(Request $request)
    {
        $this->request = $request;
    }

    public function books()
    {
        return response()->json(['books' => Book::all()]);
    }

    public function book($book)
    {
        $book = Book::find($book);
        return response()->json(['book' => $book]);
    }

    public function saveBook()
    {
        try {
            $validator = Validator::make($this->request->all(), [
                'title' => 'required|string|unique:books',
                'description' => 'required|max:500',
                'price' => 'required|min:0.01',
                'author' => 'required|max:25',
            ]);

            if ($validator->passes()) {
                $book = new Book();
                $book->title = $this->request->get('title');
                $book->price = $this->request->get('price');
                $book->author = $this->request->get('author');
                $book->description = $this->request->get('description');
                $book->save();

                return response()->json(["status" => "success", 'book' => $book]);
            } else {
                return response()->json(['status' => "failed", 'errors' => $validator->errors()->toArray()]);
            }
        } catch (\Throwable $ex) {
            return response()->json([
                "status" => "failed",
                "message" => $ex
            ], 200);
        }
    }

    public function deleteBook()
    {
        try {
            $validator = Validator::make($this->request->all(), [
                'book' => 'required',
            ]);

            if ($validator->passes()) {
                $book = Book::where('id', (int)$this->request->get('book'));
                if (isset($book)) {
                    $book->delete();
                    return response()->json(["status" => "success", "message" => "The Delete Operation Completed Successfully"]);
                } else {
                    return response()->json(["status" => "failed", "message" => "Not Found"]);
                }
            } else {
                return response()->json(['status' => "failed", 'errors' => $validator->errors()->toArray()]);
            }
        } catch (\Throwable $ex) {
            return response()->json([
                "status" => "failed",
                "message" => $ex
            ], 200);
        }
    }

    public function updateBook()
    {
        try {
            $validator = Validator::make($this->request->all(), [
                'id' => 'required',
                'title' => 'required|string|unique:books',
                'description' => 'required|max:500',
                'price' => 'required|min:0.01',
                'author' => 'required|max:25',
            ]);

            if ($validator->passes()) {
                $book = Book::where('id', (int)$this->request->get('id'));
                if (isset($book)) {


                    $book->update([
                        "title" => $this->request->get('title'),
                        "description" => $this->request->get('description'),
                        "price" => $this->request->get('price'),
                        "author" => $this->request->get('author'),
                    ]);

                    return response()->json(["status" => "success", "message" => "The Update Operation Completed Successfully"]);
                } else {
                    return response()->json(["status" => "failed", "message" => "Not Found"]);
                }
            } else {
                return response()->json(['status' => "failed", 'errors' => $validator->errors()->toArray()]);
            }
        } catch (\Throwable $ex) {
            return response()->json([
                "status" => "failed",
                "message" => $ex
            ], 200);
        }
    }
}
