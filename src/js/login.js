
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
            
            .then(function(json){
                let id = json.id
                return id
                
            })
            .then(function (id) {
              if (id > 0) {
               
                alert("User was logged in successfully!");
                location.replace("./create.html")
              };
              if(id <= 0) {
                alert("An error occured. Please try again.");
              }
            });
        },
        
        false
      );
    });
  })();
