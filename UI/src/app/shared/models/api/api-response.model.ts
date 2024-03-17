export interface ApiResponseModel<TValue> {
	status: number;
	errors?: string;
	data?: TValue;
}
