// GET
$.get("http://localhost:3000/books",function(data){})

// POST
$.post("http://localhost:3000/books",{name:"Book1"})

// PUT
$.ajax({
url:"http://localhost:3000/books/1",
method:"PUT",
data:{name:"Updated Book"}
})

// DELETE
$.ajax({
url:"http://localhost:3000/books/1",
method:"DELETE"
})
