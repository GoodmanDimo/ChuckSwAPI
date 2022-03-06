

var urlDomain = "https://localhost:44342/"
//Add a dynamic table to populate people
function addpeopleTableViewRow(People) {

    for (var i = 0; i < People.length; i++) {
        var table = document.getElementById("peopleTableView");
        var rowCount = table.rows.length;
        var row = table.insertRow(rowCount);
        row.insertCell(0).innerHTML = People[i].name;
        row.insertCell(1).innerHTML = People[i].gender;
        row.insertCell(2).innerHTML = People[i].homeWorld;
        row.insertCell(3).innerHTML = People[i].url;
    }
}


//Add a dynamic table to populate categories
function addcategoryTableDataRows(Categories) {

    for (var i = 0; i < Categories.length; i++) {
        var table = document.getElementById("categoryTableData");
        var rowCount = table.rows.length;
        var row = table.insertRow(rowCount);
        row.insertCell(0).innerHTML = '<a href="Javacsript:viewJoke(this)" onClick="Javacsript:viewJoke(this)">' + Categories[i]+ '</a>';
        row.insertCell(1).innerHTML = i;
    }
}

//create dynamic form buttoms
function createButtons() {
    document.getElementById("searchForm").innerHTML = '<input type="button" value = "Search" onClick="Javacsript:SearchResults(this)">' +                                                      '<input placeholder="Search" id="search" />';
    document.getElementById("ViewPeople").innerHTML = '<input type="button" value = "View people" onClick="Javacsript:viewPeople(this)">';
    document.getElementById("ViewCategories").innerHTML = '<input type="button" value = "View Categories" onClick="Javacsript:viewCategories(this)">';
}

//toogle view mode of components when view people button is clicked
function viewPeople() {
    document.getElementById("peopleTableView").style.display = "inline-block";
    document.getElementById("ViewCategories").style.display = "inline-block";
    document.getElementById("categoryTableData").style.display = "none";
    document.getElementById("ViewPeople").style.display = "none";
    document.getElementById("Jokes").style.display = "none";
    document.getElementById("searchResults").style.display = "none";
}

//toogle view mode of components when view categories button is clicked
function viewCategories() {
    document.getElementById("peopleTableView").style.display = "none";
    document.getElementById("categoryTableData").style.display = "inline-block";
    document.getElementById("ViewCategories").style.display = "none";
    document.getElementById("ViewPeople").style.display = "block";
    document.getElementById("searchResults").style.display = "none";
}


//toogle view mode of components when view search button is clicked, and perform a search
function SearchResults() {
    document.getElementById("peopleTableView").style.display = "none";
    document.getElementById("categoryTableData").style.display = "none";
    document.getElementById("ViewCategories").style.display = "block";
    document.getElementById("ViewPeople").style.display = "none";
    document.getElementById("Jokes").style.display = "none";
    var querystring = document.getElementById("search").value;
    document.getElementById("search").value = "";
  
    var tableHeaderRowCount = 1;
    var table = document.getElementById("SearchResultsDisplay");
    var rowCount = table.rows.length;
    for (var i = tableHeaderRowCount; i < rowCount; i++) {
        table.deleteRow(tableHeaderRowCount);
    }

    fetch(urlDomain + "search?query=" + querystring)
        .then(function (response) {
            if (response.ok) {
                return response.json();
            } else {
                return Promise.reject(response);
            }
        })
        .then(function (data) {
            searchresults = data;
            var obj = JSON.parse(data.item1);
            var obj2 = JSON.parse(data.item2);

            if (obj2.results.length < 1 && obj.total < 1) {
                document.getElementById("searchResults").innerHTML = "No search results found";
                return;
            }

            document.getElementById("searchResults").style.display = "inline-block";

            for (var i = 0; i < obj.total; i++) {
                 rowCount = table.rows.length;
                 row = table.insertRow(rowCount);
                row.insertCell(0).innerHTML = "API URL = " + obj.result[i].url;
                row.insertCell(1).innerHTML = "Joke Value = " + obj.result[i].value; 
            }

            for (var r = 0; r <= obj2.results.length; r++) {
                rowCount = table.rows.length;
                row = table.insertRow(rowCount);
                row.insertCell(0).innerHTML = "API URL: " + obj2.results[r].url;
                row.insertCell(1).innerHTML = "Name: " + obj2.results[r].name;
            }
        })
        .catch(function (error) {
            console.warn(error);
        });
}

//toogle view mode of components when a category is clicked to view a joke
function viewJoke(rowindex) {

    document.getElementById("peopleTableView").style.display = "none";
    document.getElementById("categoryTableData").style.display = "none";

    var index = rowindex.parentNode.parentNode.rowIndex;
    var table = document.getElementById("categoryTableData");
    var cellvalue = table.rows[index].cells[0].innerText;

    fetch("https://api.chucknorris.io/jokes/random?category=" + cellvalue)
        .then(function (response) {
            if (response.ok) {
                return response.json();
            } else {
                return Promise.reject(response);
            }
        })
        .then(function (data) {
            document.getElementById("Jokes").innerText = data.value
            document.getElementById("Jokes").style.display = "block"
        })
        .catch(function (error) {
            console.warn(error);
        });
}

//fetch categories
function FetchCategories() {

    document.getElementById("categoryTableData").style.display = "inline-block";
    
    fetch(urlDomain+ "chuck/categories")
        .then(function (response) {
            if (response.ok) {
                return response.json();
            } else {
                return Promise.reject(response);
            }
        })
        .then(function (data) {
            addcategoryTableDataRows(data)
        })
        .catch(function (error) {
            console.warn(error);
        });
}

//fetch people
function FetchPeople() {

    fetch(urlDomain + "swapi/people")
        .then(function (response) {
            if (response.ok) {
                return response.json();
            } else {
                return Promise.reject(response);
            }
        })
        .then(function (data) {
            addpeopleTableViewRow(data);
        })
        .catch(function (error) {
            console.error(error);
        });

}

