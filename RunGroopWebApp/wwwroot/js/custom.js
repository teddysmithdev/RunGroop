const search = document.getElementById("registerLocation");
const matchList = document.getElementById("datalistOptions");

const searchLocation = async searchText => {
    const res = await fetch('account/getlocation?'
        + new URLSearchParams({
            location: searchText
    }));
    const locationData = await res.json();

    console.log(locationData);
    let matches = locationData.data.filter(state => {
        const regex = new RegExp(`^${searchText}`, 'gi');
        return String(state.zip).match(regex) || String(state.cityName).match(regex)
    });
    if (searchText.length === 0) {
        matches = [];
    }
    outPutHtml(matches);
}

const outPutHtml = matches => {
    if (matches.length > 0) {
        const html = matches.map(match =>
            `<option value="${match.cityName}, ${match.stateCode}">`)
            .join("");
        matchList.innerHTML = html;
    }
}

search.addEventListener('input', () => {
    searchLocation(search.value);
})
