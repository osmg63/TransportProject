using AutoMapper;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Dtos;
using TransportProject.Data.Entities.Location;


namespace TransportProject.Service.Concrete
{
    public class JobService
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly S3Service _s3Service;
        public readonly IMapper _mapper;
        public JobService(IUnitOfWork unitOfWork, IMapper mapper, S3Service s3Service)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _s3Service = s3Service;
        }

        public async Task<bool> Update(CreateJobDto jobTo, CreateAddress departure, CreateAddress destination)
        {
            var dataJob = _unitOfWork.JobRepository.Get(x => x.Id == jobTo.Id);

            var dataDeparture = _unitOfWork.DepartureAddressRepository.Get(x => x.Id == departure.Id);
            var dataDestination = _unitOfWork.DestinationAddressRepository.Get(x => x.Id == destination.Id);

            if (dataJob == null || dataDeparture == null || dataDestination == null)
            {
                return false;
            }

            try
            {
                _mapper.Map(departure, dataDeparture);
                _unitOfWork.DepartureAddressRepository.SaveChanges();

                _mapper.Map(destination, dataDestination);
                _unitOfWork.DestinationAddressRepository.SaveChanges();

                _mapper.Map(jobTo, dataJob);
                _unitOfWork.JobRepository.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Hata oluştu: {ex.Message}", ex);
            }
        }


        public List<ViewJobDto> GetAllJob() { 
            var data =  _unitOfWork.JobRepository.GetAllJob();

            return data;
        
        
        
        }
        public object GetByIdJob(int id)
        {
            var data = _unitOfWork.JobRepository.GetById(id);

            return data;
        }
        public object GetJobByUserId(int id)
        {
            var data = _unitOfWork.JobRepository.GetJobByUserId(id);

            return data;
        }
        public object GetActiveJobByUserId(int id)
        {
            var data = _unitOfWork.JobRepository.GetActiveJobByUserId(id);

            return data;
        }
        public async Task<Job> AddPhotoJob(string id, IFormFile file)
        {
            var data = _unitOfWork.JobRepository.Get(x=>x.Id==Convert.ToInt32(id));


           if(data == null)
            {
                return null;
            }
           
            var result= await _s3Service.UploadFileAsync(file);
           if(result == null)
            {
                return null;
            }
            data.Photo=result;
            _unitOfWork.JobRepository.SaveChanges();

            return data;

         

        }
        public async Task<Stream> GetPhotoAsync(string fileName)
        {
             var response=  await _s3Service.DownloadFileAsync(fileName);
            return response; 
        }

        public ResponseJobDto AddJob(CreateJobDto Jobto,CreateAddress departure,CreateAddress destination)
        {
            try
            {

                var dataDestination = _unitOfWork.DestinationAddressRepository.Add(_mapper.Map<DestinationAddress>(destination));
                var dataDeparture = _unitOfWork.DepartureAddressRepository.Add(_mapper.Map<DepartureAddress>(departure));

                if (dataDestination == null || dataDeparture == null) {
                    // return new Exception("Adress kaydı başarısız");
                    return null;
                }
         


               var dataJob= _mapper.Map<Job>(Jobto);
                dataJob.IsActive = true;
                dataJob.DestinationAddressId=dataDestination.Id;
                dataJob.DepartureAddressId = dataDeparture.Id;


                var data= _unitOfWork.JobRepository.Add(dataJob);

                var result= _mapper.Map<ResponseJobDto>(data);
                return result;
            }
            catch (Exception ex) {
                return null;
            }
            
        }
        public bool ChangeJobActive(int id)
        {
            var data = _unitOfWork.JobRepository.Get(x => x.Id == id);
            if (data == null) { return false; }
            data.IsActive = true;
            _unitOfWork.JobRepository.SaveChanges();
            return true;

        }
        public bool ChangeJobInActive(int id)
        {
            var data = _unitOfWork.JobRepository.Get(x => x.Id == id);
            if (data == null) { return false; }
            data.IsActive = false;
            _unitOfWork.JobRepository.SaveChanges();
            return true;

        }
    }
}
