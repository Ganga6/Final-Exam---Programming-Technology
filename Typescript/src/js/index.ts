import axios,{
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index"

interface Match{
  id : number,
  fTeam : string,
  fTeamGoals: number,
  sTeam : string,
  sTeamGoals: number,
}

//url for the rest webservice at Azure
let UEFAurl: string = "https://uefaexam.azurewebsites.net/api/Match/";
let GetAllButton: HTMLButtonElement = <HTMLButtonElement> document.getElementById("getAllButton");
GetAllButton.addEventListener('click',GetAllMatches);

function GetAllMatches():void{
    document.getElementById("table").innerHTML = "<tr><th>Match ID</th><th>First Team</th><th>First Team Goals</th><th>Second Team</th><th>Second Team Goals</th></tr>";
    axios.get<Match[]>(UEFAurl)
    .then(function(response:AxiosResponse<Match[]>) : void{
        response.data.forEach((smatch:Match) => {
            var tr = "<tr>"+"<th>"+smatch.id+"</th>"+"<th>"+smatch.fTeam+"</th>"+"<th>"+smatch.fTeamGoals+"</th>"+"<th>"+smatch.sTeam+"</th>"+"<th>"+smatch.sTeamGoals+"</th>"+"</tr>";
            document.getElementById("table").innerHTML += tr;
            console.debug(smatch.fTeam+" "+smatch.sTeam);
        })
    })
    .catch(function (error:AxiosError) : void{                          
            console.log(error);
        })
}


function AddMatch():void{
    var fgoals : HTMLInputElement = <HTMLInputElement> document.getElementById("fTeamGoals");
    var sgoals : HTMLInputElement = <HTMLInputElement> document.getElementById("sTeamGoals");
    var steam : HTMLInputElement = <HTMLInputElement> document.getElementById("sTeam");
    var fteam : HTMLInputElement = <HTMLInputElement> document.getElementById("fTeam");

    var postmatch:Match = {id: undefined, fTeam : fteam.value, fTeamGoals : Number(fgoals.value), sTeam: steam.value ,sTeamGoals : Number(sgoals.value)};
    
    axios.post<Match>(UEFAurl, postmatch)
    .then(function (response :  AxiosResponse): void
    {
        console.log("Statuscode is :" + response.status);
    })
    .catch( function (error:AxiosError) : void{                          
            console.log(error);
        })
}

let AddButton: HTMLButtonElement = <HTMLButtonElement> document.getElementById("addButton");
AddButton.addEventListener('click',AddMatch);

function GetMatchById():void{
    var getid : HTMLInputElement = <HTMLInputElement> document.getElementById("getbyid");
    var id : number = Number(getid.value);
    console.log(id);
    axios.get<Match>(UEFAurl+id)
    .then(function (response: AxiosResponse<Match>) : void
    {
        var responsematch : Match = response.data;
        var resultText : string = responsematch.id + " " + responsematch.fTeam + " " + responsematch.fTeamGoals + " " + responsematch.sTeam + " " + responsematch.sTeamGoals;
        document.getElementById("content").innerHTML = resultText;
    })
    .catch( function (error:AxiosError) : void{                          
        console.log(error);
    })
}

let GetByIdButton: HTMLButtonElement = <HTMLButtonElement> document.getElementById("getbyidbutton");
GetByIdButton.addEventListener('click',GetMatchById);

function GetWinner():void{
    var getid : HTMLInputElement = <HTMLInputElement> document.getElementById("winnerID");
    var id : number = Number(getid.value);
    axios.get<string>("https://uefaexam.azurewebsites.net/api/Winner/"+id)
    .then(function (response: AxiosResponse<string>) : void
    {
        document.getElementById("winner").innerHTML = response.data;
        console.log(response.data);
    })
    .catch( function (error:AxiosError) : void{                          
        console.log(error);
    })
}

let WinnerButton: HTMLButtonElement = <HTMLButtonElement> document.getElementById("winnerbutton");
WinnerButton.addEventListener('click',GetWinner);
