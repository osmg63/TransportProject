using AutoMapper;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Dtos.AddressDtos;
using TransportProject.Data.Dtos.JobDtos;
using TransportProject.Data.Entities.Location;
using TransportProject.Data.Filters;
using TransportProject.Service.Abstract;


namespace TransportProject.Service.Concrete
{
    public class JobService:IJobService
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IS3Service _s3Service;
        public readonly IMapper _mapper;
        public JobService(IUnitOfWork unitOfWork, IMapper mapper, IS3Service s3Service)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _s3Service = s3Service;
        }

        public async Task<bool> Update(CreateJobDto jobTo, CreateAddress departure, CreateAddress destination)
        {
            var dataJob =await _unitOfWork.JobRepository.Get(x => x.Id == jobTo.Id);

            var dataDeparture =await _unitOfWork.DepartureAddressRepository.Get(x => x.Id == departure.Id);
            var dataDestination =await _unitOfWork.DestinationAddressRepository.Get(x => x.Id == destination.Id);

            if (dataJob == null || dataDeparture == null || dataDestination == null)
            {
                return false;
            }

            try
            {
                _mapper.Map(departure, dataDeparture);
                await _unitOfWork.SaveChangeAsync();

                _mapper.Map(destination, dataDestination);
                await _unitOfWork.SaveChangeAsync();
                jobTo.Photo = dataJob.Photo;
                _mapper.Map(jobTo, dataJob);
                await _unitOfWork.SaveChangeAsync();
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
            var data = await _unitOfWork.JobRepository.Get(x=>x.Id==Convert.ToInt32(id));


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
            await _unitOfWork.SaveChangeAsync();

            return data;

         

        }
        public async Task<Stream> GetPhotoAsync(string fileName)
        {
             var response=  await _s3Service.DownloadFileAsync(fileName);
            return response; 
        }

        public async  Task<ResponseJobDto> AddJob(CreateJobDto Jobto,CreateAddress departure,CreateAddress destination)
        {
            try
            {

                var dataDestination = await _unitOfWork.DestinationAddressRepository.Add(_mapper.Map<DestinationAddress>(destination));
                var dataDeparture =await _unitOfWork.DepartureAddressRepository.Add(_mapper.Map<DepartureAddress>(departure));
                await _unitOfWork.SaveChangeAsync();


                if (dataDestination == null || dataDeparture == null) {
                    // return new Exception("Adress kaydı başarısız");
                    return null;
                }
         


                var dataJob= _mapper.Map<Job>(Jobto);
                dataJob.IsActive = true;
                dataJob.DestinationAddressId=dataDestination.Id;
                dataJob.DepartureAddressId = dataDeparture.Id;


                var data=await _unitOfWork.JobRepository.Add(dataJob);
                await _unitOfWork.SaveChangeAsync();

                var result= _mapper.Map<ResponseJobDto>(data);
                return result;
            }
            catch (Exception ex) {
                return null;
            }
            
        }
        public async Task<bool> ChangeJobActive(int id)
        {
            var data = await _unitOfWork.JobRepository.Get(x => x.Id == id);
            if (data == null) { return false; }
            data.IsActive = true;
            await _unitOfWork.SaveChangeAsync();
            return true;

        }
        public async Task<bool> ChangeJobInActive(int id)
        {
            var data =await _unitOfWork.JobRepository.Get(x => x.Id == id);
            if (data == null) { return false; }
            data.IsActive = false;
            await _unitOfWork.SaveChangeAsync();
            return true;

        }
        public async Task<PaginationResult<ViewJobDto>> GetPaginationView(FilterDto filter)
        {
            return await _unitOfWork.JobRepository.GetPaginationView(filter);
        }
    }
}
