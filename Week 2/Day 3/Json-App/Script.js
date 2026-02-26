const posts = [
  {
    "userId": 1,
    "id": 1,
    "title": "sunt aut facere repellat provident occaecati",
    "body": "quia et suscipit suscipit recusandae consequuntur expedita"
  },
  {
    "userId": 1,
    "id": 2,
    "title": "qui est esse",
    "body": "est rerum tempore vitae sequi sint nihil reprehenderit"
  },
  {
    "userId": 1,
    "id": 3,
    "title": "ea molestias quasi exercitationem",
    "body": "et iusto sed quo iure voluptatem occaecati omnis"
  }
];const container = document.getElementById("postsContainer");

posts.forEach(function(post) {

    const postDiv = document.createElement("div");
    postDiv.classList.add("post");

    postDiv.innerHTML = `
        <div class="title">${post.title}</div>
        <div class="user">User ID: ${post.userId}</div>
        <p>${post.body}</p>
    `;

    container.appendChild(postDiv);

});