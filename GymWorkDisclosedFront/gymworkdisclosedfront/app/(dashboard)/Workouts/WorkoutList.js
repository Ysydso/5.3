export const getStaticProps = async () =>{
    const res = await fetch('http://localhost:5206/api/GymGoer/7895ce77-e4af-4f07-a489-31b51229f7e0')
    const data = await res.json()
    
    return {
        props: { GymGoer: data }
    }
}

const Details = ({ GymGoer }) => {
  return (
      <div>
          <h1>{GymGoer.name}</h1>
      </div>
  );
}


