var id = localStorage.getItem("userId");
var token = localStorage.getItem("authToken");
if (token) {
  helloUserFunc();
  logoutBtn();
} else logout();
(function () {
  function toJSONString(form) {
    var obj = {};
    var elements = form.querySelectorAll("input");
    for (var i = 0; i < elements.length; ++i) {
      var element = elements[i];
      var name = element.name;
      var value = element.value;

      if (name) {
        obj[name] = value;
      }
    }

    return JSON.stringify(obj);
  }

  document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById("signup");
    var output;
    form.addEventListener(
      "submit",
      async function (e) {
        e.preventDefault();
        var message = toJSONString(this);
        output = message;
        await fetch("https://dndwebapi.azurewebsites.net/api/User/Register", {
          method: "POST",
          headers: {
            "content-encoding": "gzip",
            "content-type": "application/json; charset=utf-8",
          },
          body: output,
        })
          .then(function (response) {
            console.log(response);
            return response.status;
          })
          .then(function (status) {
            if (status == 200) {
              alert("User was registred!");
              document.getElementById("loginButton").click();
            }
            if (status >= 400) {
              alert("An error occured. Please try again.");
            }
          });
      },
      false
    );
  });
})();

(function () {
  function toJSONString(form) {
    var obj = {};
    var elements = form.querySelectorAll("input");
    for (var i = 0; i < elements.length; ++i) {
      var element = elements[i];
      var name = element.name;
      var value = element.value;

      if (name) {
        obj[name] = value;
      }
    }

    return JSON.stringify(obj);
  }

  document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById("login");
    var output;
    form.addEventListener(
      "submit",
      async function (e) {
        e.preventDefault();
        var message = toJSONString(this);
        output = message;
        console.log(output);
        await fetch("https://dndwebapi.azurewebsites.net/api/Token/", {
          method: "POST",
          headers: {
            "content-encoding": "gzip",
            "content-type": "application/json; charset=utf-8",
          },
          body: output,
        })
          .then(function (response) {
            return response.json();
          })

          .then(function (json) {
            id = json.id;
            token = json.token;
            localStorage.setItem("userId", id);
            localStorage.setItem("authToken", token);
            return id;
          })
          .then(function (id) {
            if (id > 0) {
              document.getElementById("btnClose").click();
              helloUserFunc();
            }
            if (id <= 0) {
              alert("An error occured. Please try again.");
            }
          });
      },
      false
    );
  });
})();
function helloUserFunc() {
  fetch(`https://dndwebapi.azurewebsites.net/api/User/${id}`)
    .then(function (response) {
      console.log(response);
      return response.json();
    })
    .then(function (json) {
      let userName = json.userName;
      console.log(userName);
      logoutBtn();
      document.getElementById("helloUser").innerHTML = `Hello ${userName}!`;
      document.getElementById("helloUser").className = `alert alert-success alert-dismissible fade show w-25`;

      if (userName){
        setInterval(hideUser, 5000);
      }
    });
}

function hideUser() {
  document.getElementById("helloUser").style.display = "none";
}

function logoutBtn() {
  document.getElementById("logoutButton").style.display = "inline";
  document.getElementById("loginButton").style.display = "none";
  document.getElementById("signupButton").style.display = "none";
}

function logout() {
  localStorage.removeItem("userId");
  localStorage.removeItem("authToken");
  document.getElementById("helloUser").style.display = "inline";
  document.getElementById("loginButton").style.display = "inline";
  document.getElementById("signupButton").style.display = "inline";
  document.getElementById("logoutButton").style.display = "none";
  document.getElementById("helloUser").innerHTML = `Please sign up or login.`;
  document.getElementById("helloUser").className = `alert alert-warning alert-dismissible fade show w-25`;
}
