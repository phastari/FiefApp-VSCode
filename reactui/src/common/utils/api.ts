export async function callApi(
  method: string,
  url: string,
  path: string,
  data?: any
) {
  let headers = {};
  let token = localStorage.getItem('fief_token');
  if (token !== null) {
    headers = {
      'Content-Type': 'application/json',
      Authorization: `Bearer ${token}`
    };
  } else {
    headers = {
      'Content-Type': 'application/json'
    };
  }

  const res = await fetch(`${url}/api${path}`, {
    method,
    headers: headers,
    body: JSON.stringify(data)
  });
  return res.json();
}
